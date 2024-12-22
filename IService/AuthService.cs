using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbConnection;
using Service.DTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Sieve.Models;

namespace Service
{
    public class AuthService
    {
        private readonly ApplicationDbContext _ApplicationDbContext;
        private readonly ILogger<AuthService> _logger;
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private readonly PasswordHasher<User> _passwordHasher = new PasswordHasher<User>();
        public AuthService(ApplicationDbContext applicationDbContext, ILogger<AuthService> logger, IWebHostEnvironment env, IConfiguration configuration)
        {
            _ApplicationDbContext = applicationDbContext;
            _logger = logger;
            _env = env;
            _configuration= configuration;
        }

        public async Task<string> Register(UserRegisterDTO userDTO)
        {
            try
            {
                // Check if email already exists
                var emailExistingUser = await _ApplicationDbContext.Users.FirstOrDefaultAsync(x => x.Email == userDTO.Email);
                if (emailExistingUser != null)
                {
                    return "Email is already registered.";
                }

                // Validate fields
                if (string.IsNullOrEmpty(userDTO.Name) ||
                    string.IsNullOrEmpty(userDTO.Email) ||
                    string.IsNullOrEmpty(userDTO.Password))
                {
                    return "All fields are required!";
                }

                // Validate image upload
                if (userDTO.Image == null || userDTO.Image.Length == 0)
                {
                    return "Image is required!";
                }

                // Hash password
                string hashedPassword = _passwordHasher.HashPassword(null, userDTO.Password);
                // Save image to the server
                string uniqueFileName = $"{Guid.NewGuid()}_{userDTO.Image.FileName}";
                string imagePath = Path.Combine(_env.WebRootPath, "UserImages", uniqueFileName);

                using (var fs = new FileStream(imagePath, FileMode.Create))
                {
                    await userDTO.Image.CopyToAsync(fs);
                }
                if (string.IsNullOrEmpty(userDTO.RoleId.ToString()))
                {
                    return "Role Id Is required";
                }
                Role roleExistingUser = await _ApplicationDbContext.Roles.FirstOrDefaultAsync(x=>x.Id==userDTO.RoleId);
              if(roleExistingUser == null)
                {
                    return $"Role Id Is not Assign This {emailExistingUser}";
                }
                // Create user entity
                User user = new User()
                {
                    Name = userDTO.Name,
                    Email = userDTO.Email,
                    Password = hashedPassword,
                    Image = uniqueFileName,
                    IsActive = true,
                    RoleId = roleExistingUser.Id,
                    CreateBy= "System Generated",
                    CreateAt=DateTime.UtcNow
                    
                };

                // Save user to the database
                await _ApplicationDbContext.Users.AddAsync(user);
                await _ApplicationDbContext.SaveChangesAsync();

                return $"User registered successfully: {user.Email}";
            }
            catch (Exception ex)
            {
                // Generate log file
                string logFileName = $"Log_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
                string logFilePath = Path.Combine(_env.WebRootPath, "Logs", logFileName);

                Directory.CreateDirectory(Path.Combine(_env.WebRootPath, "Logs"));

                await File.WriteAllTextAsync(logFilePath, $"Error: {ex.Message}\nStackTrace: {ex.StackTrace}");

                // Log the error using ILogger
                _logger.LogError($"Exception in Register Method: {ex.Message}");
                return "An error occurred while registering the user. Please try again later.";
            }
        }

        public async Task<IEnumerable<UserGetAllDTO>> GellAll()
        {
            var userRole = await _ApplicationDbContext.Users.Include(x => x.Role).ToListAsync();

          return  userRole.Select(x=>new UserGetAllDTO {
                  UserId=x.Id,
                  UserName=x.Name,
                  Email=x.Email,
                  Image=x.Image,
                  UserIsActive=x.IsActive,
                  RoleId=x.RoleId,
                  RoleName=x.Role.Name,
                  CreateBy=x.CreateBy,
                  CreateAt=x.CreateAt,
                  UpdateAt=x.UpdateAt
          });
           
        }

        public async Task<UserFindByIdDTO?> FindUserById(int id)
        {
            var userRole = await _ApplicationDbContext.Users.Include(x => x.Role).FirstOrDefaultAsync(u=>u.Id==id);

            UserFindByIdDTO userFindByIdDTO = new UserFindByIdDTO() 
            {
                UserId = userRole.Id,
                UserName = userRole.Name,
                Email = userRole.Email,
                Image = userRole.Image,
                UserIsActive = userRole.IsActive,
                RoleId = userRole.RoleId,
                RoleName = userRole.Role.Name,
                CreateBy = userRole.CreateBy,
                CreateAt = userRole.CreateAt,
                UpdateAt = userRole.UpdateAt
            };

            return userFindByIdDTO;
          

            //return await _ApplicationDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

        }
            

        public async Task<string> UpdateRegister(int id, UserUpdateRegisterDTO userUpdateRegisterDTO)
        {
            if (id <= 0)
            {
                return $"id is null or 0 =>{id}";
            }
            var userUpdate = await _ApplicationDbContext.Users.FindAsync(id);
            if (userUpdate == null)
            {
                return $"This User is not in My record Id{id}";
            }

            // Save image to the server
            string uniqueFileName = $"{Guid.NewGuid()}_{userUpdateRegisterDTO.Image.FileName}";
            string imagePath = Path.Combine(_env.WebRootPath, "UserImages", uniqueFileName);
            FileStream fs = new FileStream(imagePath, FileMode.Create);
            userUpdateRegisterDTO.Image.CopyTo(fs);


            userUpdate.Name = userUpdateRegisterDTO.Name;
            userUpdate.Email = userUpdateRegisterDTO.Email;
            userUpdate.Password = _passwordHasher.HashPassword(userUpdate, userUpdateRegisterDTO.Password);
            userUpdate.Image = userUpdateRegisterDTO.Image.FileName;// only name
            userUpdate.Image = imagePath;// only name
            userUpdate.IsActive = userUpdateRegisterDTO.IsActive;
            userUpdate.RoleId=userUpdateRegisterDTO.RoleId;
            userUpdate.UpdateAt = DateTime.Now;
            userUpdate.CreateBy = "System Generated";

            _ApplicationDbContext.Users.Update(userUpdate);
            await _ApplicationDbContext.SaveChangesAsync();

            return $"User updated successfully: {userUpdate.Name}";
        }

        public async Task<string> DeleteUser(int id)
        {
            if (id <= 0)
            {
                return $"Invalid user ID: {id}";
            }

            var userToDelete = await _ApplicationDbContext.Users.FindAsync(id);
            if (userToDelete == null)
            {
                return $"User not found with ID: {id}";
            }

            // Remove the user from the database
            _ApplicationDbContext.Users.Remove(userToDelete);
            await _ApplicationDbContext.SaveChangesAsync();

            return $"User with ID {id} deleted successfully.";
        }
        //register complete

        //Login
        public async Task<string> Login(UserLoginDTO userDTO)
        {
            try
            {
                if (string.IsNullOrEmpty(userDTO.Email) || string.IsNullOrEmpty(userDTO.Password))
                {
                    return "Email and password are required!";
                }

                // Find user by email
                var user = await _ApplicationDbContext.Users.FirstOrDefaultAsync(x => x.Email == userDTO.Email);
                if (user == null)
                {
                    return "User not found";
                }

                // Validate password
                if (_passwordHasher.VerifyHashedPassword(null, user.Password, userDTO.Password) != PasswordVerificationResult.Success)
                {
                    return "Invalid password.";
                }

                // Generate and return JWT token
                var token = await GenerateJwtToken(user); // Ensure you are awaiting the task here
                return $"Token => {token}";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in Login Method: {ex.Message}");
                return "An error occurred while logging in. Please try again.";
            }
        }



        private async Task<string> GenerateJwtToken(User user)
        {
            var userWithRoles = await _ApplicationDbContext.Users.Include(x => x.Role).ThenInclude(ur => ur.RolePrivileges).FirstOrDefaultAsync(x => x.Id == user.Id);
            if (userWithRoles == null)
            {
                throw new Exception("User not found.");
            }
            var claims = new List<Claim> {

                        new Claim(JwtRegisteredClaimNames.Sub,_configuration["Jwt:Subject"]),
                        new Claim("Id",user.Id.ToString()),
                        new Claim("Email",user.Email.ToString()),
                    };

            // Add roles to claims
            //if (userWithRoles.UserRoles != null)
            //{
            //    foreach (var userRole in userWithRoles.UserRoles)
            //    {
            //        claims.Add(new Claim(ClaimTypes.Role, userRole.role.Name));
            //    }
            //}

        

            if(userWithRoles.Role!=null && userWithRoles.RoleId==userWithRoles.Role.Id)
            {
                claims.Add(new Claim(ClaimTypes.Role, userWithRoles.Role.Name));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(30),
                        signingCredentials: signIn

                                    );
            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenValue;

        }

    }
}

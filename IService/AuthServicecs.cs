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

namespace Service
{
    public class AuthServicecs
    {
        private readonly ApplicationDbContext _ApplicationDbContext;
        private readonly ILogger<AuthServicecs> _logger;
        private readonly IWebHostEnvironment _env;

        public AuthServicecs(ApplicationDbContext applicationDbContext, ILogger<AuthServicecs> logger, IWebHostEnvironment env)
        {
            _ApplicationDbContext = applicationDbContext;
            _logger = logger;
            _env = env;
        }

        //public async Task<string> Register(UserRegisterDTO userDTO)
        //{
        //    var emexistingUser = await _ApplicationDbContext.Users.FirstOrDefaultAsync(x => x.Email == userDTO.Email);
        //    if (emexistingUser !=null) 
        //    {
        //        return "Email is Already Exist.";
        //    }
        //    if (string.IsNullOrEmpty(userDTO.Name) || string.IsNullOrEmpty(userDTO.Email) || string.IsNullOrEmpty(userDTO.Password))
        //    {
        //        return "All fields are required!";
        //    }
        //    string hashedPassword = HashPassword(userDTO.Password);
        //    User user = new User() 
        //    {
        //    Name = userDTO.Name,
        //    Email = userDTO.Email,
        //    Password = hashedPassword,
            
        //    };
        //}

        private string HashPassword(string password)
        {
            byte[] salt = new byte[16];
            using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt); // Generate a random salt
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8)); // 256-bit hash

            return hashed;
        }
    }
}

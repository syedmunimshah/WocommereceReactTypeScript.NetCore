using DbConnection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.DTO;

namespace WocommereceReactTypeScript.NetCore.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthServicecs _authServicecs;
        public AuthController(AuthServicecs authServicecs)
        {
            _authServicecs = authServicecs;
        }
        //Register start
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDTO userDTO)
        {
            var result = await _authServicecs.Register(userDTO);
            if (result.Contains("successfully"))
            {
                return Ok(new { message = result });
            }
            return BadRequest(new { error = result });
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GellAll()
        {
         return await _authServicecs.GellAll();
            
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRegister(int id, UserUpdateRegisterDTO userUpdateRegisterDTO) 
        {
           var updateUser =await  _authServicecs.UpdateRegister(id, userUpdateRegisterDTO);
            return Ok($"{updateUser}");
        }

        [HttpGet]
        public async Task<IActionResult> FindUserById(int id)
        {
            var user = await _authServicecs.FindUserById(id);
            if (user == null)
            {
                return NotFound($"User with ID {id} not found.");
            }
            return Ok(user);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _authServicecs.DeleteUser(id);
            if (result.Contains("not found"))
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        // Register end
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDTO loginDTO)
        {
            var token = await _authServicecs.Login(loginDTO);

            if (token == "Invalid email or password.")
            {
                return Unauthorized("Invalid credentials");
            }

            return Ok(new { Token = token });
        }



        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Admin()
        {
            return Ok("Welcome to the Admin Dashboard!");
        }


        [Authorize(Roles = "User")]
        [HttpGet]
        public IActionResult User()
        {
            return Ok("Welcome to the User Dashboard!");
        }


    } 
}

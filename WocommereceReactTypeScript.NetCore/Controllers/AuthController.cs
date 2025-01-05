using DbConnection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.DTO;
using Sieve.Models;
using Sieve.Services;

namespace WocommereceReactTypeScript.NetCore.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _AuthService;
        private readonly SieveProcessor _sieveProcessor;
        public AuthController(AuthService AuthService,SieveProcessor sieveProcessor)
        {
            _AuthService = AuthService;
            _sieveProcessor= sieveProcessor;
        }
        //Register start
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDTO userDTO)
        {
            var result = await _AuthService.Register(userDTO);
            if (result.Contains("successfully"))
            {
                return Ok(new { message = result });
            }
            return BadRequest(new { error = result });
        }

        [HttpGet]
        public async Task<IEnumerable<UserGetAllDTO>> GetAll()
        {
            return await _AuthService.GetAll();

        }

        //[HttpGet]
        //public IActionResult GetAll(SieveModel sieveModel)
        //{
        //   var models = _AuthService.GetAll();
        //    models = _sieveProcessor.Apply(sieveModel, models);
        //    return Ok(models.ToList());

        //}


        [HttpPost]
        public async Task<IActionResult> UpdateRegister(int id, UserUpdateRegisterDTO userUpdateRegisterDTO)
        {
            var updateUser = await _AuthService.UpdateRegister(id, userUpdateRegisterDTO);
            return Ok($"{updateUser}");
        }

        [HttpGet]
        public async Task<IActionResult> FindUserById(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID: {id}");
            }

            var user = await _AuthService.FindUserById(id);
            if (user == null)
            {
                return NotFound($"User with ID {id} not found.");
            }

            return Ok(user);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _AuthService.DeleteUser(id);
            if (result.Contains("not found"))
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        //// Register end
        [HttpPost]
          public async Task<IActionResult> Login(UserLoginDTO loginDTO)
        {
            var token = await _AuthService.Login(loginDTO);

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


        [Authorize(Roles = "Employee")]
        [HttpGet]
        public IActionResult User()
        {
            return Ok("Welcome to the User Dashboard!");
        }
        [Authorize(Roles = "Hr")]
        [HttpGet]
        public IActionResult Hr()
        {
            return Ok("Welcome to the Hr Dashboard!");
        }


    } 
}

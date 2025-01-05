using DbConnection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.DTO;

namespace WocommereceReactTypeScript.NetCore.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleService _roleService;
        public RoleController(RoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(AddRoleDTO addRoleDTO)
        {
            var result = await _roleService.AddRole(addRoleDTO);
            if (result.Contains("successfully")) 
            {
                return Ok(new { message = result });
            }
            return BadRequest(new { error = result });

        }
        [HttpPost]
        public async Task<IActionResult> UpdateRole(UpdateRoleDTO updateRoleDTO, int id) 
        {
            var result = await _roleService.UpdateRole(updateRoleDTO,id);
            if (result.Contains("successfuly"))
            {
                return Ok(new { message = result });
            }
            return BadRequest(new { error = result });

        }

        [HttpGet]
        public async Task<IEnumerable<GetAllUserRoleDTO>> GetAll()
        {
            return await _roleService.GetAllUserRolePrivilages();

        }

        [HttpGet]

        public async Task<IActionResult> FindRoleById(int id) 
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID: {id}");
            }

            var Role = await _roleService.FindRoleById(id);

            if (Role==null) {
                return NotFound($"User with ID {id} not found.");

            }
            return Ok(Role);

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _roleService.DeleteUser(id);
            if (result.Contains("not found"))
            {
                return NotFound(result);
            }
            return Ok(result);
        }
    }
}

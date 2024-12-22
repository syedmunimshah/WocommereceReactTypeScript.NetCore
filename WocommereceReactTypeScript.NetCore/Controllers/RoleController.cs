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
    }
}

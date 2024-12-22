using DbConnection;
using Microsoft.EntityFrameworkCore;
using Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class RoleService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public RoleService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;    
        }
        public async Task<string> AddRole(AddRoleDTO addRoleDTO)
        {
            if (string.IsNullOrEmpty(addRoleDTO.Name)) {
                return $"{addRoleDTO.Name} is null OR Empty String";
               
            }
            var existingRole = await _applicationDbContext.Roles.FirstOrDefaultAsync(x => x.Name == addRoleDTO.Name);
            if (existingRole != null)
            {
                return $"This Role Name Is Already In My Table {existingRole.Name}";
            }

            Role role = new Role() 
            { 
                Name= addRoleDTO.Name,
                CreateBy = "System Generated",
                IsActive= true,
                CreateAt=DateTime.UtcNow
        
                //CreateAt=dat
            };
            await _applicationDbContext.Roles.AddAsync(role);
            await _applicationDbContext.SaveChangesAsync();
            return $"This Role is Register successfully {role.Name}";

        }
    }
}

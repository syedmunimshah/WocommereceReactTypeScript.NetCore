using DbConnection;
using DbConnection.Migrations;
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
            if (string.IsNullOrEmpty(addRoleDTO.Name))
            {
                return $"{addRoleDTO.Name} is null OR Empty String";
            }

            // Check if the role already exists in the database
            var existingRole = await _applicationDbContext.Roles
                .FirstOrDefaultAsync(x => x.Name == addRoleDTO.Name);

            // If the role doesn't exist, create a new one
            if (existingRole == null)
            {
                Role role = new Role()
                {
                    Name = addRoleDTO.Name,
                    CreateBy = "System Generated",
                    IsActive = true,
                    CreateAt = DateTime.UtcNow
                };

                await _applicationDbContext.Roles.AddAsync(role);
                await _applicationDbContext.SaveChangesAsync(); // Save to get the role ID

                if (role.Id == 0)
                {
                    return $"Role is not in record {role.Name}";
                }

                // Get privileges based on the provided list of PrivilegesId
                var matchedPrivileges = await _applicationDbContext.Privileges
                    .Where(x => addRoleDTO.PrivilegesId.Contains(x.Id))
                    .ToListAsync();

                // Create RolePrivileges for the new role
                var rolePrivilegesList = matchedPrivileges.Select(priv => new RolePrivileges
                {
                    RoleId = role.Id,
                    PrivilegesId = priv.Id,
                    IsActive = true,
                    CreateAt = DateTime.UtcNow
                }).ToList();

                await _applicationDbContext.RolePrivileges.AddRangeAsync(rolePrivilegesList);
                await _applicationDbContext.SaveChangesAsync();

                return $"Role {role.Name} registered successfully!";
            }
            else
            {
                // Role exists, now update the RolePrivileges
                // First, remove existing privileges for this role
                var existingRolePrivileges = await _applicationDbContext.RolePrivileges
                    .Where(rp => rp.RoleId == existingRole.Id)
                    .ToListAsync();

                _applicationDbContext.RolePrivileges.RemoveRange(existingRolePrivileges);

                // Add new privileges based on the provided PrivilegesId
                var matchedPrivileges = await _applicationDbContext.Privileges
                    .Where(x => addRoleDTO.PrivilegesId.Contains(x.Id))
                    .ToListAsync();

                var rolePrivilegesList = matchedPrivileges.Select(priv => new RolePrivileges
                {
                    RoleId = existingRole.Id,
                    PrivilegesId = priv.Id,
                    IsActive = true,
                    CreateAt = DateTime.UtcNow
                }).ToList();

                await _applicationDbContext.RolePrivileges.AddRangeAsync(rolePrivilegesList);
                await _applicationDbContext.SaveChangesAsync();

                return $"Role {existingRole.Name} privileges updated successfully!";
            }
        }

    }
}

using DbConnection;
using DbConnection.Migrations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Service.DTO.GetAllUserRoleDTO;

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
                return "Role name is Empty and null";
            }   
           
            var existing =await _applicationDbContext.Roles.FirstOrDefaultAsync(x=>x.Name==addRoleDTO.Name);
            if (existing == null) 
            {
                Role role = new Role()
                {
                    Name = addRoleDTO.Name,
                    CreateAt = DateTime.Now,
                    IsActive = true,
                    CreateBy = "System Generated"
                };
                await _applicationDbContext.Roles.AddAsync(role);
                await _applicationDbContext.SaveChangesAsync();

                if (addRoleDTO.PrivilegesId != null && addRoleDTO.PrivilegesId.Count !=0)
                {
                    var matchPrivileges = await _applicationDbContext.Privileges.Where(x => addRoleDTO.PrivilegesId.Contains(x.Id)).ToListAsync();
               
                    if(matchPrivileges != null && matchPrivileges.Count !=0 )
                    {

                            var rolePrivileges = matchPrivileges.Select(pri=> new RolePrivileges
                            {
                                RoleId = role.Id ,
                                PrivilegesId = pri.Id,
                                IsActive=true,
                                CreateAt=DateTime.UtcNow
                            }).ToList();

                        await _applicationDbContext.RolePrivileges.AddRangeAsync(rolePrivileges);
                        await _applicationDbContext.SaveChangesAsync();

                     

                    }
                    else { return "Not match Privileges Id"; }

                }
                else{ return "Role You Created but not Assign Privilege Id."; }
            }
            else { return $"this Role Is Already created {addRoleDTO.Name}"; }
            return $" Add This Role{addRoleDTO.Name} successfully";
        }


        public async Task<string> UpdateRole(UpdateRoleDTO updateRoleDTO,int id)
        {
            if(string.IsNullOrEmpty(updateRoleDTO.Name)|| string.IsNullOrEmpty(updateRoleDTO.PrivilegesId.ToString()) || string.IsNullOrEmpty(updateRoleDTO.IsActive.ToString())) 
            {
                return "user input is null or empty string";
            }
            var existing = await _applicationDbContext.Roles.FirstOrDefaultAsync(x => x.Id == id);
            if (existing != null) 
            {
                existing.Name = updateRoleDTO.Name;
                existing.IsActive = updateRoleDTO.IsActive;
                existing.UpdateAt = DateTime.UtcNow;
                existing.CreateBy = "System Generated";

                _applicationDbContext.Roles.Update(existing);
                await _applicationDbContext.SaveChangesAsync();

               var  existingRolePrivileges =await _applicationDbContext.RolePrivileges.Where(x => x.RoleId == existing.Id).ToListAsync();
                _applicationDbContext.RolePrivileges.RemoveRange(existingRolePrivileges);

                var matchedPrivileges =await _applicationDbContext.Privileges.Where(x => updateRoleDTO.PrivilegesId.Contains(x.Id)).ToListAsync();

                var rolePrivilegesList = matchedPrivileges.Select(pri => new RolePrivileges
                {
                    RoleId = existing.Id,
                    PrivilegesId = pri.Id,
                    UpdateAt = DateTime.UtcNow,
                    IsActive = true


                }).ToList();

                await _applicationDbContext.RolePrivileges.AddRangeAsync(rolePrivilegesList);
                await _applicationDbContext.SaveChangesAsync();
                return "Update is successfuly run";
            }

            else { return $"Role table have no id found : {existing?.Id}"; }
        }


public async Task<PagedResult<GetAllUserRoleDTO>> GetAllUserRolePrivilages(int pageNumber, int pageSize)
    {

            var userRolePrivilage =  _applicationDbContext.Users
                .Include(x => x.Role)
                .ThenInclude(r => r.RolePrivileges)
                .ThenInclude(rp => rp.Privileges).AsQueryable();

            var totalRecords = await userRolePrivilage.CountAsync(); // Total records count
            
            var users = await userRolePrivilage
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).Select(x => new GetAllUserRoleDTO
                {
                    userId = x.Id,
                    userName = x.Name,
                    userEmail = x.Email,
                    userImage = x.Image,
                    userIsActive = x.IsActive,
                    roleId = x.RoleId,
                    roleName = x.Role.Name,
                    privilages = x.Role.RolePrivileges
                .Where(rp => rp.IsActive)
                .Select(rp => new GetAllUserRoleDTO.Privilage
                {
                    privilagesID = rp.PrivilegesId,
                    privilagesname = rp.Privileges.Slug
                })
                .ToList()
                }).ToListAsync();

            return new PagedResult<GetAllUserRoleDTO>
            {
                TotalRecords = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize),
                Data = users
            };

           
    }

        public async Task<GetByIdUserRoleDTO> FindRoleById(int id)
        {
           var RoleId = await _applicationDbContext.Roles.Include(rp => rp.RolePrivileges).ThenInclude(p=>p.Privileges).FirstOrDefaultAsync(x => x.Id == id);

            if (RoleId != null)
            {
                return new GetByIdUserRoleDTO
                {
                    RoleId = RoleId.Id,
                    RoleName = RoleId.Name,
                    privilages = RoleId.RolePrivileges.Select(rp => new GetByIdUserRoleDTO.Privilage
                    {
                        privilagesID = rp.Privileges.Id,
                        privilagesname = rp.Privileges.Slug
                    }
                   ).ToList()
                };
            }
            else return null;

        }

        public async Task<string> DeleteUser(int id)
        {
            if (id <= 0)
            {
                return $"Invalid role ID: {id}";
            }

            var roleToDelete = await _applicationDbContext.Roles.FindAsync(id);
            if (roleToDelete == null)
            {
                return $"Role not found with ID: {id}";
            }

            var existingRolePrivileges = await _applicationDbContext.RolePrivileges.Where(x => x.RoleId == roleToDelete.Id).ToListAsync();
            _applicationDbContext.RolePrivileges.RemoveRange(existingRolePrivileges);
            _applicationDbContext.Roles.Remove(roleToDelete);
            await _applicationDbContext.SaveChangesAsync();

            return $"Role with ID {id} deleted successfully.";
        }

     






    }
}

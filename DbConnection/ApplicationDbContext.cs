using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace DbConnection
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Privileges> Privileges { get; set; }
        public DbSet<RolePrivileges> RolePrivileges { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Privileges>().HasData(
                new Privileges() { Id=  1, Slug= "user-Register",Type="Post",UrlPath= "Auth/Register",IsActive=true,CreateAt=DateTime.UtcNow,UpdateAt=null },
                new Privileges() { Id = 2, Slug = "user-GellAll", Type = "Get", UrlPath = "Auth/GellAll", IsActive = true, CreateAt = DateTime.UtcNow, UpdateAt = null },
                new Privileges() { Id = 3, Slug = "user-UpdateRegister", Type = "Post", UrlPath = "Auth/UpdateRegister", IsActive = true, CreateAt = DateTime.UtcNow, UpdateAt = null },
                new Privileges() { Id = 4, Slug = "user-FindUserById", Type = "Get", UrlPath = "Auth/FindUserById", IsActive = true, CreateAt = DateTime.UtcNow, UpdateAt = null },
                new Privileges() { Id = 5, Slug = "user-DeleteUser", Type = "Delete", UrlPath = "Auth/DeleteUser", IsActive = true, CreateAt = DateTime.UtcNow, UpdateAt = null },
                new Privileges() { Id = 6, Slug = "user-Login", Type = "Post", UrlPath = "Auth/Login", IsActive = true, CreateAt = DateTime.UtcNow, UpdateAt = null },
                new Privileges() { Id = 7, Slug = "Admin", Type = "Get", UrlPath = "Auth/Admin", IsActive = true, CreateAt = DateTime.UtcNow, UpdateAt = null },
                new Privileges() { Id = 8, Slug = "User", Type = "Get", UrlPath = "Auth/User", IsActive = true, CreateAt = DateTime.UtcNow, UpdateAt = null },
                new Privileges() { Id = 9, Slug = "Hr", Type = "Get", UrlPath = "Auth/Hr", IsActive = true, CreateAt = DateTime.UtcNow, UpdateAt = null },
                new Privileges() { Id = 10, Slug = "Role-AddRole", Type = "Post", UrlPath = "Role/AddRole", IsActive = true, CreateAt = DateTime.UtcNow, UpdateAt = null },
                new Privileges() { Id = 11, Slug = "Role-GellAll", Type = "Get", UrlPath = "Role/GellAll", IsActive = true, CreateAt = DateTime.UtcNow, UpdateAt = null },
                new Privileges() { Id = 12, Slug = "Role-UpdateRole", Type = "Post", UrlPath = "Role/UpdateRole", IsActive = true, CreateAt = DateTime.UtcNow, UpdateAt = null },
                new Privileges() { Id = 13, Slug = "Role-FindRoleById", Type = "Get", UrlPath = "Role/FindRoleById", IsActive = true, CreateAt = DateTime.UtcNow, UpdateAt = null },
                new Privileges() { Id = 14, Slug = "Role-Delete", Type = "Delete", UrlPath = "Role/Delete", IsActive = true, CreateAt = DateTime.UtcNow, UpdateAt = null }
                );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }


    }

}

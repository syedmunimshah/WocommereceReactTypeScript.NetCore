using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConnection
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<RolePrivileges> RolePrivilegess { get; set; }
        public bool IsActive { get; set; }

        public DateTime CreateAt { get; set; } = DateTime.Now;
    }
}

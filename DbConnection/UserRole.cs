using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConnection
{
    public class UserRole
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        public User user { get; set; }

        public int RoleId { get; set; }
        public Role role { get; set; }
        public bool IsActive { get; set; }

        public DateTime dateTime { get; set; } = DateTime.Now;
    }
}

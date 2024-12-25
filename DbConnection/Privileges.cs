using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConnection
{
    public class Privileges
    {
        [Key]
        public int Id { get; set; }
        public string Slug { get; set; } //Unique Name (e.g., "user-list", "user-update")
        public string Type { get; set; } // HTTP Type (GET, POST, PUT, DELETE)
        public string UrlPath { get; set; }  //API endpoint path (e.g., /api/users)
        public bool IsActive { get; set; }
        public DateTime? CreateAt { get; set; } 

        public DateTime? UpdateAt { get; set; }
        public ICollection<RolePrivileges> RolePrivileges { get; set; }


    }
}

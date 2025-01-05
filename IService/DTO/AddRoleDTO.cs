using DbConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    public class AddRoleDTO
    {
       
        public string Name { get; set; }
        public List<int> PrivilegesId { get; set; }
        public bool IsActive { get; set; }
    }

    public class UpdateRoleDTO
    {

        public string Name { get; set; }
        public List<int> PrivilegesId { get; set; }
        public bool IsActive { get; set; }
    }
}

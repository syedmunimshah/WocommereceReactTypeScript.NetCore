using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    public class GetByIdUserRoleDTO
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public List<Privilage> privilages { get; set; }
        public class Privilage {
        public int privilagesID { get; set; }
        public string privilagesname { get; set; }
        }
    }
}

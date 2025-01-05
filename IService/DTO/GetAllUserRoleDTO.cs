using DbConnection;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
        public class GetAllUserRoleDTO
        {
            public int userId { get; set; }
            public string userName { get; set; }
            public string userEmail { get; set; }
            public string userImage { get; set; }
            public bool userIsActive { get; set; }
            public int roleId { get; set; }
            public string roleName { get; set; }
            public List<Privilage> privilages  { get; set; }

            public class Privilage
            {
                public int privilagesID { get; set; }
                public string privilagesname { get; set; }
            }

        }
    
   
}

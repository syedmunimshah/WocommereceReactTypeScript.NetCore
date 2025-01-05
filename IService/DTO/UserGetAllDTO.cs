using DbConnection;
using Sieve.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    public class UserGetAllDTO
    {
        public int UserId { get; set; }
     
        [Sieve(CanFilter =true,CanSort =true)]
        public string UserName { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public string Email { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public string Image { get; set; }
        [Sieve(CanFilter = true, CanSort = true)]

        public bool UserIsActive { get; set; }
        public int RoleId { get; set; }
        [Sieve(CanFilter = true, CanSort = true)]

        public string RoleName { get; set; }
        [Sieve(CanFilter = true, CanSort = true)]

        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string CreateBy { get; set; }
    }

    public class UserFindByIdDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public bool UserIsActive { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string CreateBy { get; set; }
    }

}

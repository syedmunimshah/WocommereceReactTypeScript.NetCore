using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConnection
{
    public class RoleScreen
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public int ScreenId { get; set; }
        public Screen Screen { get; set; }
        public bool IsActive { get; set; }
        public DateTime dateTime { get; set; } = DateTime.Now;

    }
}

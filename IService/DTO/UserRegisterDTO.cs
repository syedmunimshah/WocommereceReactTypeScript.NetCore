using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbConnection;
using Microsoft.AspNetCore.Http;
using static System.Net.Mime.MediaTypeNames;

namespace Service.DTO
{
    public class UserRegisterDTO
    {
        
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IFormFile Image { get; set; }
    
    }

    public class UserLoginDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }
}

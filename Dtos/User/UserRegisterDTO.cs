using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_project.Dtos.User
{
    public class UserRegisterDTO
    {
        public string Name { get; set; }
        public string Username { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string phone_number { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}

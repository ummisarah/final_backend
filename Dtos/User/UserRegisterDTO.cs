using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_project.Dtos.User
{
    public class UserRegisterDTO
    {
        public string Name { get; set; } = "Anonymous";
        public string Username {get; set;} = string.Empty;
        public string Email {get; set;} = string.Empty;
        public string PhoneNumber {get; set;} = string.Empty;
        public string Address {get; set;} = string.Empty;
        public string Password {get; set;} = "12345678";
        public string? ImageURL {get; set;}
    }
}

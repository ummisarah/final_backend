using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_project.Models
{
    public class User
    {
        public int Id {get; set;}
        public string Name { get; set; } = "Anonymous";
        public string Username {get; set;} = string.Empty;
        public string Email {get; set;} = string.Empty;
        public string PhoneNumber {get; set;} = string.Empty;
        public string Address {get; set;} = string.Empty;
        public byte[] PasswordHash {get; set;}
        public byte[] PasswordSalt {get; set;}
        public Cart? cart {get; set;}
        public Wishlist? wishlist {get; set;}
    }
}
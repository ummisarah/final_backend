using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using final_project.Models.CartModel;

namespace final_project.Models
{
    public class Cart
    {
         public int Id { get; set; }

        public User? User { get; set; }
        
        public int UserId {get; set;}

        public List<CartItem>? CartItems { get; set; }
    }
}
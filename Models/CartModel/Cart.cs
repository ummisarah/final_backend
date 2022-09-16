using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using final_project.Models.CartModel;

namespace final_project.Models
{
    public class Cart
    {
         public int id { get; set; }

        public User? user { get; set; }
        
        public int userId {get; set;}

        public List<CartItem>? cartItems { get; set; }
    }
}
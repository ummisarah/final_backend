using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_project.Models
{
    public class Cart
    {
         public int id { get; set; }

        public User? user { get; set; }
        
        public int userId {get; set;}

        public List<Product>? product { get; set; }

        public int quantity { get; set; }

        public string? notes { get; set; }
    }
}
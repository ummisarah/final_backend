using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_project.Models
{
    public class Wishlist
    {
        public int id { get; set; }
        public int product_id { get; set; }
        public int user_id { get; set; }
    }
}
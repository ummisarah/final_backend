using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_project.Models.WishlistModel
{
    public class WishlistItem
    {
        public int id { get; set; }

        public Product? product { get; set; }
        
        public int productId { get; set; }
    }
}
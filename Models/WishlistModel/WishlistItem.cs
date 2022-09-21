using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_project.Models.WishlistModel
{
    public class WishlistItem
    {
        public int Id { get; set; }

        public Product? Product { get; set; }
        
        public int ProductId { get; set; }
    }
}
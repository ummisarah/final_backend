using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_project.Dtos.Wishlist
{
    public class WishlistDTO
    {
        
        public int Id { get; set; }
        
        public int ProductId { get; set; }

        public List<WishlistItemDTO>? WishlistItems { get; set; }
    }
}
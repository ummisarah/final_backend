using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using final_project.Models.WishlistModel;

namespace final_project.Models
{
    public class Wishlist
    {
        public int Id { get; set; }
        
        public User? UserWishlist {get; set;}

        public int UserId { get; set; }
        
        public List<WishlistItem>? WishlistItems { get; set; }
    }
}
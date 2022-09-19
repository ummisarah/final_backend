using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using final_project.Models.WishlistModel;

namespace final_project.Models
{
    public class Wishlist
    {
        public int id { get; set; }
        
        public User? user_wishlist {get; set;}

        public int userId { get; set; }
        
        public List<WishlistItem>? wishlistItems { get; set; }
    }
}
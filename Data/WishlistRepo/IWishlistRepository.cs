using System;
using System.Collections.Generic;
using System.Linq;
using final_project.Models;
using System.Threading.Tasks;
using final_project.Models.WishlistModel;

namespace final_project.Data.WishlistRepo
{
    public interface IWishlistRepository
    {
        Task<ServiceResponse<WishlistItem>> AddWishlist(WishlistItem wishlistItem);
        Task<ServiceResponse<Wishlist>> GetWishlist();
        Task<ServiceResponse<WishlistItem>> DeleteWishlist(int id);
    }
}
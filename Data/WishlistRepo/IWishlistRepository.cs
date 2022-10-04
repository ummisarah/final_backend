using System;
using System.Collections.Generic;
using System.Linq;
using final_project.Models;
using System.Threading.Tasks;
using final_project.Models.WishlistModel;
using final_project.Dtos.Wishlist;

namespace final_project.Data.WishlistRepo
{
    public interface IWishlistRepository
    {
        Task<ServiceResponse<WishlistItemDTO>> AddWishlist(WishlistItemDTO addWishlistDTO);
        Task<ServiceResponse<WishlistDTO>> GetWishlist();
        Task<ServiceResponse<WishlistItemDTO>> DeleteWishlist(int id);
    }
}
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
        Task<ServiceResponse<WishlistDTO>> AddWishlist(int ProductId);
        Task<ServiceResponse<WishlistDTO>> GetWishlist();
        Task<ServiceResponse<WishlistDTO>> DeleteWishlist(int id);
    }
}
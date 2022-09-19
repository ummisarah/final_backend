using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using final_project.Models;
using final_project.Models.WishlistModel;
using Microsoft.EntityFrameworkCore;

namespace final_project.Data.WishlistRepo
{
    public class WishlistRepository : IWishlistRepository
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor; 
        public WishlistRepository(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }
        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext!.User
            .FindFirstValue(ClaimTypes.NameIdentifier));

        public async Task<ServiceResponse<WishlistItem>> AddWishlist(WishlistItem wishlistItem)
        {
            var response = new ServiceResponse<WishlistItem>();

            WishlistItem item = new WishlistItem
            {
                productId = wishlistItem.productId
            };

            _context.WishlistItems.Add(item);

            var wishlistUser = await _context.Wishlists
                .Include(item => item.user_wishlist)
                .Include(item => item.wishlistItems)
                .Where(wishlist => wishlist.id == GetUserId())
                .FirstOrDefaultAsync();

            wishlistUser.wishlistItems.Add(item);

            await _context.SaveChangesAsync();

            response.Data = item;

            return response;
        }
            
        public async Task<ServiceResponse<Wishlist>> GetWishlist()
        {
            var response = new ServiceResponse<Wishlist>();

            var result = await _context.Wishlists
                .Include(item => item.user_wishlist)
                .Where(item => item.id ==  GetUserId())
                .FirstOrDefaultAsync();

            response.Data = result;
            response.Message = "Data Retrieved";

            return response;
        }

        public async Task<ServiceResponse<WishlistItem>> DeleteWishlist(int id)
        {
            var response = new ServiceResponse<WishlistItem>();

            WishlistItem? item = await _context.WishlistItems
                .Where(wishlist => wishlist.id == id).FirstOrDefaultAsync();
                _context.WishlistItems.Remove(item);
                await _context.SaveChangesAsync();
                response.Data = item;
                return response;
        }
    }
}
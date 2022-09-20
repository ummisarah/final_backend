using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using final_project.Dtos.Wishlist;
using final_project.Models;
using final_project.Models.WishlistModel;
using Microsoft.EntityFrameworkCore;

namespace final_project.Data.WishlistRepo
{
    public class WishlistRepository : IWishlistRepository
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor; 
        private readonly IMapper _mapper;
        public WishlistRepository(DataContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }
        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext!.User
            .FindFirstValue(ClaimTypes.NameIdentifier));

        public async Task<ServiceResponse<WishlistDTO>> AddWishlist(int productId)
        {
            var response = new ServiceResponse<WishlistDTO>();

            WishlistItem wishlistItem = new WishlistItem 
            {
                productId = productId
            };
            

            WishlistDTO? wishlistItemDTO = _mapper.Map<WishlistDTO>(wishlistItem);            

            _context.WishlistItems.Add(wishlistItem);

            var wishlistUser = await _context.Wishlists
                .Include(item => item.user_wishlist)
                .Include(item => item.wishlistItems)
                .Where(wishlist => wishlist.id == GetUserId())
                .FirstOrDefaultAsync();

            wishlistUser.wishlistItems.Add(wishlistItem);

            await _context.SaveChangesAsync();

            response.Data = wishlistItemDTO;

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

        public async Task<ServiceResponse<WishlistDTO>> DeleteWishlist(int id)
        {
            var response = new ServiceResponse<WishlistDTO>();

            WishlistItem? item = await _context.WishlistItems
                .Where(wishlist => wishlist.id == id).FirstOrDefaultAsync();

            WishlistDTO? wishlistDTO = _mapper.Map<WishlistDTO>(item);

            _context.WishlistItems.Remove(item);
            await _context.SaveChangesAsync();
            response.Data = wishlistDTO;
            
            return response;
        }
    }
}
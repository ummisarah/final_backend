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
                ProductId = productId
            };
            
            Wishlist? wishlist = await _context.Wishlists
                .Where(u => u.Id == GetUserId())
                .FirstOrDefaultAsync();
            
            wishlistItem.Wishlist = wishlist;

            WishlistDTO? wishlistItemDTO = _mapper.Map<WishlistDTO>(wishlistItem);            

            _context.WishlistItems.Add(wishlistItem);

            // var wishlistUser = await _context.Wishlists
            //     .Include(item => item.UserWishlist)
            //     .Include(item => item.WishlistItems)
            //     .Where(wishlist => wishlist.Id == GetUserId())
            //     .FirstOrDefaultAsync();

            // wishlistUser.WishlistItems.Add(wishlistItem);

            await _context.SaveChangesAsync();

            response.Data = wishlistItemDTO;
            response.Message = "Data Added!";

            return response;
        }
            
        public async Task<ServiceResponse<WishlistDTO>> GetWishlist()
        {
            var response = new ServiceResponse<WishlistDTO>();

            var result = await _context.Wishlists
                .Include(item => item.UserWishlist)
                .Where(item => item.Id ==  GetUserId())
                .FirstOrDefaultAsync();

            var WishlistItem = await _context.WishlistItems
                .Include(item => item.Product)
                .Include(item => item.Wishlist)
                .Where(item => item.Wishlist == result)
                .ToListAsync();

            WishlistDTO wishlistDTO = _mapper.Map<WishlistDTO>(result);

            response.Data = wishlistDTO;
            response.Message = "Data Retrieved";

            return response;
        }

        public async Task<ServiceResponse<WishlistDTO>> DeleteWishlist(int id)
        {
            var response = new ServiceResponse<WishlistDTO>();

            WishlistItem? item = await _context.WishlistItems
                .Where(wishlist => wishlist.Id == id).FirstOrDefaultAsync();

            WishlistDTO? wishlistDTO = _mapper.Map<WishlistDTO>(item);

            _context.WishlistItems.Remove(item);
            await _context.SaveChangesAsync();
            
            response.Data = wishlistDTO;
            response.Message = "Data Removed!";

            return response;
        }
    }
}
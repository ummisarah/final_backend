using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using final_project.Models.CartModel;
using Microsoft.EntityFrameworkCore;

namespace final_project.Data.CartRepo
{
    
    public class CartRepository : ICartRepository
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CartRepository(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
           _context = context;
            
        }
         private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext!.User
            .FindFirstValue(ClaimTypes.NameIdentifier));

        public async Task<ServiceResponse<Cart>> GetAllCart()
        {
            var response = new ServiceResponse<Cart>();

            var result = await _context.Carts
                .Include(item => item.user)
                .Where(item => item.id == GetUserId())
                .FirstOrDefaultAsync();

            response.Data = result;
            response.Message = "Data Retrieved";

            return response;
        }

        public async Task<ServiceResponse<CartItem>> AddCart(CartItem cartItem)
        {
            var response = new ServiceResponse<CartItem> ();

            CartItem item = new CartItem
            {
                productId = cartItem.productId,
                quantity = cartItem.quantity,
                notes = cartItem.notes
            };

            _context.CartItems.Add(item);

            var cartUser = await _context.Carts
                .Include(item => item.user)
                .Include(item => item.cartItems)
                .Where(cart => cart.id == GetUserId())
                .FirstOrDefaultAsync();

            cartUser.cartItems.Add(item);

            await _context.SaveChangesAsync();

            response.Data = item;

            return response;
        }
    }
}
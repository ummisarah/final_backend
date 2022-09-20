using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using final_project.Dtos;
using final_project.Dtos.Cart;
using final_project.Models;
using final_project.Models.CartModel;
using Microsoft.EntityFrameworkCore;

namespace final_project.Data.CartRepo
{
    
    public class CartRepository : ICartRepository
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        public CartRepository(DataContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _mapper = mapper;
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

        public async Task<ServiceResponse<AddToCartDTO>> AddCart(AddToCartDTO addToCartDTO)
        {
            var response = new ServiceResponse<AddToCartDTO>();

            
            // CartItem item = new CartItem
            // {
            //     productId = addToCartDTO.productId,
            //     quantity = addToCartDTO.quantity,
            //     notes = addToCartDTO.notes
            // };

            // _context.CartItems.Add(item);

            CartItem cartItem = _mapper.Map<CartItem>(addToCartDTO);
            Cart? cartUser = await _context.Carts
                .Where(u => u.id == addToCartDTO.cartId)
                .FirstOrDefaultAsync();

            cartItem.cart = cartUser;
            _context.CartItems.Add(cartItem);

            await _context.SaveChangesAsync();

            //response.Data = item.Select(item => _mapper.Map<AddToCartDTO>(item)).Tolist();

            return response;
        }

        public async Task<ServiceResponse<CartItem>> EditCart(CartItemDTO cartItemDTO)
        {
            var response = new ServiceResponse<CartItem> ();
            
            CartItem? item = await _context.CartItems
                .Where(cart => cart.id == cartItemDTO.id).FirstOrDefaultAsync();
            if (cartItemDTO.quantity == 0)
                {
                    _context.Remove(item);
                }
            item.quantity = cartItemDTO.quantity;
            item.notes = cartItemDTO.notes;
            await _context.SaveChangesAsync();
            response.Data = item;
            return response;
        }

        public async Task<ServiceResponse<CartItemDTO>> DeleteCart(int id)
        {
            var response = new ServiceResponse<CartItemDTO>();

            CartItem? item = await _context.CartItems
                .Where(cart => cart.id == id).FirstOrDefaultAsync();
            
            if(item != null)
            {
                CartItemDTO? cartItem = _mapper.Map<CartItemDTO>(item);
                _context.CartItems.Remove(item);
                await _context.SaveChangesAsync();
                response.Data = cartItem;
                return response;
            }

            response.Success = false;
            response.Message = "ID not found";
            return response;
        }

        public Task<ServiceResponse<AddToCartDTO>> AddCart(CartItem cartItem)
        {
            throw new NotImplementedException();
        }
    }
}
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
                .Include(item => item.User)
                .Where(item => item.Id == GetUserId())
                .FirstOrDefaultAsync();

            response.Data = result;
            response.Message = "Data Retrieved";

            return response;
        }

        public async Task<ServiceResponse<AddToCartDTO>> AddCart(AddToCartDTO addToCartDTO)
        {
            var response = new ServiceResponse<AddToCartDTO>();

            CartItem cartItem = _mapper.Map<CartItem>(addToCartDTO);
            Cart? cartUser = await _context.Carts
                .Where(u => u.Id == addToCartDTO.Id)
                .FirstOrDefaultAsync();

            cartItem.Cart = cartUser;
            _context.CartItems.Add(cartItem);

            await _context.SaveChangesAsync();

            //response.Data = item.Select(item => _mapper.Map<AddToCartDTO>(item)).Tolist();

            return response;
        }

        public async Task<ServiceResponse<CartItem>> EditCart(CartItemDTO cartItemDTO)
        {
            var response = new ServiceResponse<CartItem> ();
            
            CartItem? item = await _context.CartItems
                .Where(cart => cart.Id == cartItemDTO.Id).FirstOrDefaultAsync();
            if (cartItemDTO.Quantity == 0)
                {
                    _context.Remove(item);
                }
            item.Quantity = cartItemDTO.Quantity;
            item.Notes = cartItemDTO.Notes;
            await _context.SaveChangesAsync();
            response.Data = item;
            return response;
        }

        public async Task<ServiceResponse<CartItemDTO>> DeleteCart(int id)
        {
            var response = new ServiceResponse<CartItemDTO>();

            CartItem? item = await _context.CartItems
                .Where(cart => cart.Id == id).FirstOrDefaultAsync();
            
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
    }
}
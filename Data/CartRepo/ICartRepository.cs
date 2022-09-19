using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using final_project.Dtos;
using final_project.Dtos.Cart;
using final_project.Models;
using final_project.Models.CartModel;

namespace final_project.Data.CartRepo
{
    public interface ICartRepository
    {
        Task<ServiceResponse<AddToCartDTO>> AddCart(AddToCartDTO addToCartDTO);
        Task<ServiceResponse<Cart>> GetAllCart();
        Task<ServiceResponse<CartItem>> EditCart(CartItemDTO cartItemDTO);
        Task<ServiceResponse<CartItem>> DeleteCart(int id);
    }
}
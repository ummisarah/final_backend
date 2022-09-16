using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using final_project.Models;
using final_project.Models.CartModel;

namespace final_project.Data.CartRepo
{
    public interface ICartRepository
    {
        Task<ServiceResponse<CartItem>> AddCart(CartItem cartItem);
        Task<ServiceResponse<Cart>> GetAllCart();
    }
}
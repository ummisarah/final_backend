using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using final_project.Data.CartRepo;
using final_project.Dtos;
using final_project.Dtos.Cart;
using final_project.Models;
using final_project.Models.CartModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace final_project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;
        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
            
        }

        [AllowAnonymous]
        [HttpPost("AddToCart")]
        public async Task<ActionResult<ServiceResponse<CartItem>>> AddCart(AddToCartDTO addToCartDTO)
        {
            var response = await _cartRepository.AddCart(addToCartDTO);
            return Ok(response); 
        }

        [AllowAnonymous]
        [HttpGet("GetAllCart")]
        public async Task<ActionResult<ServiceResponse<Cart>>> GetAllCart()
        {
            var response = await _cartRepository.GetAllCart();
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("EditCart")]
        public async Task<ActionResult<ServiceResponse<CartItem>>> EditCart(CartItemDTO cartItemDTO)
        {
            var response = await _cartRepository.EditCart(cartItemDTO);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpDelete("DeleteCartItem")]
        public async Task<ActionResult<ServiceResponse<CartItemDTO>>> DeleteCart(int id)
        {
            var response = await _cartRepository.DeleteCart(id);
            return Ok(response);
        }
    }
}
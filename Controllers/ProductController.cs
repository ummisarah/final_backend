using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using final_project.Data.CartRepo;
using final_project.Data.ProductRepo;
using final_project.Data.WishlistRepo;
using final_project.Dtos;
using final_project.Dtos.Cart;
using final_project.Models;
using final_project.Models.CartModel;
using final_project.Models.WishlistModel;
using Microsoft.AspNetCore.Mvc;

namespace final_project.Controllers
{
    [ApiController]
    [Route("controller")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepo;
        private readonly ICartRepository _cartRepository;
        private readonly IWishlistRepository _wishlistRepository;
        public ProductController(IProductRepository productRepo, ICartRepository cartRepository, IWishlistRepository wishlistRepository)
        {
            _wishlistRepository = wishlistRepository;
            _cartRepository = cartRepository;
            _productRepo = productRepo;
            
        }

        [HttpGet("GetAllItem")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetAllItem()
        {
            var response = await _productRepo.GetAllItem();
            
            return Ok(response);
        }


        [HttpPost("AddToCart")]
        public async Task<ActionResult<ServiceResponse<CartItem>>> AddCart(AddToCartDTO addToCartDTO)
        {
            var response = await _cartRepository.AddCart(addToCartDTO);
            return Ok(response); 
        }

        [HttpGet("GetAllCart")]
        public async Task<ActionResult<ServiceResponse<Cart>>> GetAllCart()
        {
            var response = await _cartRepository.GetAllCart();
            return Ok(response);
        }

        [HttpPost("EditCart")]
        public async Task<ActionResult<ServiceResponse<CartItem>>> EditCart(CartItemDTO cartItemDTO)
        {
            var response = await _cartRepository.EditCart(cartItemDTO);
            return Ok(response);
        }

        [HttpDelete("DeleteCart")]
        public async Task<ActionResult<ServiceResponse<CartItem>>> DeleteCart(int id)
        {
            var response = await _cartRepository.DeleteCart(id);
            return Ok(response);
        }

        [HttpPost("AddToWishlist")]
        public async Task<ActionResult<ServiceResponse<WishlistItem>>> AddWishlist(WishlistItem wishlistItem)
        {
            var response = await _wishlistRepository.AddWishlist(wishlistItem);
            return Ok(response);
        }

        [HttpGet("GetWishlist")]
        public async Task<ActionResult<ServiceResponse<Wishlist>>> GetWishlist()
        {
            var response = await _wishlistRepository.GetWishlist();
            return Ok(response);
        }

        [HttpDelete("DeleteWishlist")]
        public async Task<ActionResult<ServiceResponse<WishlistItem>>> DeleteWishlist(int id)
        {
            var response = await _wishlistRepository.DeleteWishlist(id);
            return Ok(response);
        }

        // [HttpPost("AddNewProduct")]
        // public async  Task<ActionResult<ServiceResponse<int>>> PostProduct(Product request)
        // {
        //     var response = await _productRepo.PostProduct(
        //         request.product_name,
        //         request.description,
        //         // request.size,
        //         request.price,
        //         request.stock,
        //         request.categories,
        //         request.image_url
        //     );
        //     if(!response.Success)
        //     {
        //         return BadRequest(response);
        //     }
        //     return Ok(response);
        // }
    }
}
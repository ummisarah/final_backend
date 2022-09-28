using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using final_project.Dtos;
using final_project.Dtos.Cart;
using final_project.Dtos.Category;
using final_project.Dtos.Product;
using final_project.Dtos.User;
using final_project.Dtos.Wishlist;
using final_project.Models;
using final_project.Models.CartModel;
using final_project.Models.WishlistModel;

namespace final_project
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserRegisterDTO, User>();
            CreateMap<Product, ProductDTO>();
            CreateMap<AddToCartDTO, CartItem>();
            CreateMap<CartItem, CartItemDTO>();
            CreateMap<Wishlist, WishlistDTO>();
            CreateMap<WishlistItem, WishlistItemDTO>();
            CreateMap<WishlistItemDTO, WishlistItem>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<Cart, CartDTO>();
        }
    }
}
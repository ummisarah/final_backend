using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using final_project.Dtos.Product;

namespace final_project.Dtos.Cart
{
    public class CartProductDTO
    {
        public int Id { get; set; }

        public List<ProductCartDTO>? CartItemList { get; set; }
    }
}
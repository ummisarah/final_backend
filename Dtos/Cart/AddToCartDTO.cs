using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_project.Dtos.Cart
{
    public class AddToCartDTO
    {
        public int cartId { get; set; }
        
        public int productId { get; set; }

        public int quantity { get; set; } = 1;

        public string? notes { get; set; }
    }
}
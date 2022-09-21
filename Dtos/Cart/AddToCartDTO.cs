using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_project.Dtos.Cart
{
    public class AddToCartDTO
    {
        public int CartId { get; set; }
        
        public int ProductId { get; set; }

        public int Quantity { get; set; } = 1;

        public string? Notes { get; set; }
    }
}
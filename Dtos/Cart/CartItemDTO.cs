using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_project.Dtos
{
    public class CartItemDTO
    {
        public int id { get; set ;}
        // public GetProductDto product { get; set; }
        public int productId { get; set; }
        public int quantity { get; set; } = 1;
        public string? notes { get; set; }
    }
}
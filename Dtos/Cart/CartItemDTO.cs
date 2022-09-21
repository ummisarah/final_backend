using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_project.Dtos
{
    public class CartItemDTO
    {
        public int Id { get; set ;}
        // public GetProductDto product { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; } = 1;
        public string? Notes { get; set; }
    }
}
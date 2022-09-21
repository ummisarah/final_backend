using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_project.Models.CartModel
{
    public class CartItem
    {
        public int Id { get; set; }
        public Product? Product { get; set; }
        
        public int ProductId { get; set; }

        public int Quantity { get; set; } = 1;

        public string? Notes { get; set; }
        public Cart? Cart {get; set;}
    }
}
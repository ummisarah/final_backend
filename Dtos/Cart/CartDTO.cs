using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_project.Dtos.Cart
{
    public class CartDTO
    {
        public int Id { get; set; }

        public List<CartItemDTO>? CartItems { get; set; }
    }
}
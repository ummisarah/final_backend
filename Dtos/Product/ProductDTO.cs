using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_project.Dtos.Product
{
    public class ProductDTO
    {

        public string product_name { get; set; } = string.Empty;

        public string description { get; set; } = string.Empty;

        public int price { get; set; }

        public int stock { get; set; }

        public string image_url { get; set; } = string.Empty;
    }
}
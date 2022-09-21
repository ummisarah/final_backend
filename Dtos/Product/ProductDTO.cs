using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using final_project.Dtos.Category;
using final_project.Models;

namespace final_project.Dtos.Product
{
    public class ProductDTO
    {

        public int Id {get; set;}
        
        public string ProductName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int Price { get; set; }

        public int Stock { get; set; }

        public string ImageURL { get; set; } = string.Empty;

        public CategoryDTO Category { get; set; }
    }
}
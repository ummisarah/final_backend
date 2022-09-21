using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_project.Models
{
    public class Category
    {
        public int Id {get; set;}
        public string? category {get; set;}
        public string? ImageURL {get; set;}
        public List<Product>? Products {get; set;}
    }
}
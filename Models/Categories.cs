using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_project.Models
{
    public class Category
    {
        public int id {get; set;}
        public string? category {get; set;}
        public string? image_url {get; set;}
        public List<Product>? products {get; set;}
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace final_project.Data.ProductRepo
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        public ProductRepository(DataContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;
        }
        // public async Task<ServiceResponse<int>> PostProduct(string product_name, string description, int price, int stock, Category category, string image_url)
        // {
        //     var response = new ServiceResponse<int>();
        //     var product = await _context.Products.FirstOrDefaultAsync(item => item.product_name == product_name);

        //     if(product == null)
        //     {
        //         Product newArrival = new Product
        //         {
        //             product_name = product_name,
        //             description = description,
        //             // size = size,
        //             price = price,
        //             stock = stock,
        //             new Category {category = category},
        //             image_url = image_url
        //         };

        //         _context.Add(newArrival);
        //         await _context.SaveChangesAsync();

        //         response.Data = newArrival.id;
        //         response.Success = true;
        //         response.Message = "Product Added!";
        //         return response;
        //     }

        //     response.Success = false;
        //     response.Message = "Product Already Exist!";
        //     return response;
        // }
    }
}
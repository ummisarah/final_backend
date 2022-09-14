// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;

// namespace final_project.Data.ProductRepo
// {
//     public class ProductRepository : IAuthRepository
//     {
//         private readonly DataContext _context;
//         private readonly IConfiguration _configuration;
//         public ProductRepository(DataContext context, IConfiguration configuration)
//         {
//             _configuration = configuration;
//             _context = context;
//         }
//         public async Task<ServiceResponse<int>> PostProduct(string product_name, string description, string size, int price, int stock, string categories, string image_url)
//         {
//             var response = new ServiceResponse<int>();
//             var product = await _context.Products.Where(item => item.product_name == product_name && item.size == size).FirstOrDefaultAsync();
//         }
//     }
// }
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
        public async Task<ServiceResponse<List<Product>>> GetAllItem()
        {
            var response = new ServiceResponse<List<Product>>();
            var allItem = await _context.Products
                .Include(item => item.category)
                .ToListAsync();

            response.Data = allItem;
            response.Message = "Data Retrieved";

            return response;
        }

        public async Task<ServiceResponse<Product>> GetItembyId(int id)
        {
            var response = new ServiceResponse<Product> ();

            var item = await _context.Products
                .Include(item => item.category)
                .Where(item => item.id == id)
                .FirstOrDefaultAsync();

            response.Data = item;
            response.Message = "Data Retrieved";

            return response;
        }
    }
}
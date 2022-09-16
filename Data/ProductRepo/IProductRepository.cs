using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_project.Data.ProductRepo
{
    public interface IProductRepository
    {
        // Task<ServiceResponse<int>> PostProduct(string product_name, string description, int price, int stock, string categories, string image_url);
        Task<ServiceResponse<List<Product>>> GetAllItem();
        Task<ServiceResponse<Product>> GetItembyId(int id);
    }
}
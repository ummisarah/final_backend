using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using final_project.Data.ProductRepo;
using Microsoft.AspNetCore.Mvc;

namespace final_project.Controllers
{
    [ApiController]
    [Route("controller")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepo;
        public ProductController(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        // [HttpPost("AddNewProduct")]
        // public async  Task<ActionResult<ServiceResponse<int>>> PostProduct(Product request)
        // {
        //     var response = await _productRepo.PostProduct(
        //         request.product_name,
        //         request.description,
        //         // request.size,
        //         request.price,
        //         request.stock,
        //         request.categories,
        //         request.image_url
        //     );
        //     if(!response.Success)
        //     {
        //         return BadRequest(response);
        //     }
        //     return Ok(response);
        // }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using final_project.Data.CategoryRepo;
using final_project.Dtos.Category;
using final_project.Models;
using Microsoft.AspNetCore.Mvc;

namespace final_project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            
        }

        [HttpGet("GetAllCategory")]
        public async Task<ActionResult<ServiceResponse<List<CategoryDTO>>>> GetAllCategory()
        {
            var response = await _categoryRepository.GetAllCategory();
            return Ok(response);        

        }
    }
}
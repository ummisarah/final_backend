using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using final_project.Dtos.Category;
using final_project.Models;
using Microsoft.EntityFrameworkCore;

namespace final_project.Data.CategoryRepo
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CategoryRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<CategoryDTO>>> GetAllCategory()
        {
            var response = new ServiceResponse<List<CategoryDTO>>();

            List<Category> category = await _context.Categories.ToListAsync();

            List<CategoryDTO> categoryDTO = _mapper.Map<List<CategoryDTO>>(category);

            response.Data = categoryDTO;

            return response;
        }
    }
}
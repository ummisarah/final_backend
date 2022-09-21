using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using final_project.Dtos.Category;
using final_project.Models;

namespace final_project.Data.CategoryRepo
{
    public interface ICategoryRepository
    {
        Task<ServiceResponse<List<CategoryDTO>>> GetAllCategory();
    }
}
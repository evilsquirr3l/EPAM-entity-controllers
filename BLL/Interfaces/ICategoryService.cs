using System.Collections;
using System.Collections.Generic;
using EPAM_entity.Entities;

namespace EPAM_entity.Interfaces
{
    public interface ICategoryService
    {
        void CreateCategory(CategoryDTO category);
        CategoryDTO GetCategoryById(int id);
        IEnumerable<CategoryDTO> GetCategories();
        void Dispose();
    }
}
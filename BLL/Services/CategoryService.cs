using System.Collections;
using System.Collections.Generic;
using AutoMapper;
using EPAM_entity.Entities;
using EPAM_entity.Interfaces;

namespace EPAM_entity.Services
{
    public class CategoryService : ICategoryService
    {
        private IUnitOfWork _database;
        private IMapper _mapper;

        public CategoryService(IUnitOfWork uow, IMapper mapper)
        {
            _database = uow;
            _mapper = mapper;
        }
        
        public void CreateCategory(CategoryDTO category)
        {
            var categ = _mapper.Map<Category>(category);
            _database.Categories.Add(categ);
            _database.Save();
        }

        public CategoryDTO GetCategoryById(int id)
        {
            var category = _database.Categories.Get(id);
            var categoryDTO = _mapper.Map<CategoryDTO>(category);

            return categoryDTO;
        }

        public IEnumerable<CategoryDTO> GetCategories()
        {
            var categories = _database.Categories.GetAll();

            var categoriesDTO = _mapper.Map<IEnumerable<CategoryDTO>>(categories);

            return categoriesDTO;
        }

        public void Dispose()
        {
            _database.Dispose();
        }

    }
}
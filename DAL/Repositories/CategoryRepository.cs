using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using EPAM_entity;
using EPAM_entity.Entities;
using EPAM_entity.Repositories;

namespace DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        protected ProductContext _context;

        public CategoryRepository(ProductContext context)
        {
            _context = context;
        }
        
        public Category Get(int id)
        {
            return _context.Categories.Find(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.OrderBy(c => c.Name);
        }

        public IEnumerable<Category> Find(Expression<Func<Category, bool>> predicate)
        {
            return _context.Categories.Where(predicate);
        }

        public void Add(Category entity)
        {
            _context.Categories.Add(entity);
            _context.SaveChanges();
        }

        public void Remove(Category entity)
        {
            _context.Categories.Remove(entity);
            _context.SaveChanges();
        }
    }
}
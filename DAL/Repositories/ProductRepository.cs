using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using EPAM_entity;
using EPAM_entity.Entities;
using EPAM_entity.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        protected ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            _context = context;
        }
        
        public Product Get(int id)
        {
            return _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .SingleOrDefault(p => p.ProductId == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .OrderBy(p => p.ProductName);
        }

        public IEnumerable<Product> Find(Expression<Func<Product, bool>> predicate)
        {
            return _context.Products.Where(predicate);
        }

        public void Add(Product entity)
        {
            _context.Products.Add(entity);
            _context.SaveChanges();
        }

        public void Remove(Product entity)
        {
            _context.Products.Remove(entity);
        }

        public IEnumerable<Product> GetProductsInCategory(Category category)
        {
            return _context.Products.Where(p => p.Category == category);
        }

        public IEnumerable<Product> GetProductsInSupplier(Supplier supplier)
        {
            return _context.Products.Where(p => p.Supplier == supplier);
        }

        public IEnumerable<Product> GetCheapestProducts(int numberOfProducts)
        {
            return _context.Products.OrderByDescending(p => p.Price).Take(numberOfProducts);
        }
    }
}
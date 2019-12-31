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
    public class SupplierRepository : ISupplierRepository
    {
        protected ProductContext _context;

        public SupplierRepository(ProductContext context)
        {
            _context = context;
        }
        
        public Supplier Get(int id)
        {
            return _context.Suppliers.Find(id);
        }

        public IEnumerable<Supplier> GetAll()
        {
            return _context.Suppliers.OrderBy(s => s.Name);
        }

        public IEnumerable<Supplier> Find(Expression<Func<Supplier, bool>> predicate)
        {
            return _context.Suppliers.Where(predicate);
        }

        public void Add(Supplier entity)
        {
            _context.Suppliers.Add(entity);
            _context.SaveChanges();
        }

        public void Remove(Supplier entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Supplier> GetSuppliersWithName(string name)
        {
            return _context.Suppliers.Where(s => s.Name == name).OrderBy(s => s.SupplierId);
        }
    }
}
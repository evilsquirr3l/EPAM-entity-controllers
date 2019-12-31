using System;
using DAL.Repositories;
using EPAM_entity.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EPAM_entity
{
    public class UnitOfWork : IUnitOfWork
    {
        private CategoryRepository _categoryRepository;
        private ProductRepository _productRepository;
        private SupplierRepository _supplierRepository;
        private ProductContext _dbContext;

        public UnitOfWork()
        {
            this._dbContext = new ProductContext();
        }

        public ICategoryRepository Categories
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository(_dbContext);
                }

                return _categoryRepository;
            }
        }

        public IProductRepository Products
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository = new ProductRepository(_dbContext);
                }

                return _productRepository;
            }
        }

        public ISupplierRepository Suppliers
        {
            get
            {
                if (_supplierRepository == null)
                {
                    _supplierRepository = new SupplierRepository(_dbContext);
                }

                return _supplierRepository;
            }
        }
        
        public void Save()
        {
            _dbContext.SaveChanges();
        }
        
        private bool disposed = false;
 
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
                this.disposed = true;
            }
        }
 
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
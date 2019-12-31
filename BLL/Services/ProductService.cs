using System.Collections;
using System.Collections.Generic;
using AutoMapper;
using EPAM_entity.Entities;
using EPAM_entity.Interfaces;

namespace EPAM_entity.Services
{
    public class ProductService : IProductService
    {
        private IUnitOfWork _database;
        private IMapper _mapper;

        public ProductService(IUnitOfWork uow, IMapper mapper)
        {
            _database = uow;
            _mapper = mapper;
        }
        
        public void CreateProduct(ProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _database.Products.Add(product);
            _database.Save();
        }

        public ProductDTO GetProductById(int id)
        {
            var productEntity = _database.Products.Get(id);
            var product = _mapper.Map<ProductDTO>(productEntity);

            return product;
        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            var productsEntity = _database.Products.GetAll();
            var products = _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);

            return products;
        }

        public IEnumerable<ProductDTO> GetProductsInCategory(CategoryDTO category)
        {
            var categoryEntity = _mapper.Map<Category>(category);
            var productsEntity = _database.Products.GetProductsInCategory(categoryEntity);
            var products = _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);

            return products;
        }

        public IEnumerable<ProductDTO> GetProductsInSupplier(SupplierDTO supplier)
        {
            var supplierEntity = _mapper.Map<Supplier>(supplier);
            var productsEntity = _database.Products.GetProductsInSupplier(supplierEntity);
            var products = _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);

            return products;
        }

        public IEnumerable<ProductDTO> GetCheapestProducts(int number)
        {
            var productsEntity = _database.Products.GetCheapestProducts(number);
            var products = _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);

            return products;
        }

        public void Dispose()
        {
            _database.Dispose();
        }
    }
}
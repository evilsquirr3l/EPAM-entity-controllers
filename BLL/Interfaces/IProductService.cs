using System.Collections;
using System.Collections.Generic;
using EPAM_entity.Entities;

namespace EPAM_entity.Interfaces
{
    public interface IProductService
    {
        void CreateProduct(ProductDTO productDto);
        ProductDTO GetProductById(int id);
        IEnumerable<ProductDTO> GetProducts();
        IEnumerable<ProductDTO> GetProductsInCategory(CategoryDTO category);
        IEnumerable<ProductDTO> GetProductsInSupplier(SupplierDTO supplier);
        IEnumerable<ProductDTO> GetCheapestProducts(int number);
        void Dispose();
    }
}
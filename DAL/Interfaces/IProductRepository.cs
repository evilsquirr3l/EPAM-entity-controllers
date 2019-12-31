using System.Collections;
using System.Collections.Generic;
using EPAM_entity.Entities;


namespace EPAM_entity.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetProductsInCategory(Category category);
        IEnumerable<Product> GetProductsInSupplier(Supplier supplier);
        IEnumerable<Product> GetCheapestProducts(int numberOfProducts);
    }
}
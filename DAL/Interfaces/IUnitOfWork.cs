using System;
using EPAM_entity.Repositories;

namespace EPAM_entity
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Categories { get; }
        IProductRepository Products { get; }
        ISupplierRepository Suppliers { get;  }

        void Save();
    }
}
using System.Collections;
using System.Collections.Generic;
using EPAM_entity.Entities;


namespace EPAM_entity.Repositories
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        IEnumerable<Supplier> GetSuppliersWithName(string name);
    }
}
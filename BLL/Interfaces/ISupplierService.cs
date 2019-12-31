using System.Collections;
using System.Collections.Generic;
using EPAM_entity.Entities;

namespace EPAM_entity.Interfaces
{
    public interface ISupplierService
    {
        void CreateSupplier(SupplierDTO supplier);
        SupplierDTO GetSupplierById(int id);
        IEnumerable<SupplierDTO> GetSuppliers();
        IEnumerable<SupplierDTO> GetSuppliersByName(string name);
        void Dispose();
    }
}
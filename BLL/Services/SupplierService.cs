using System.Collections;
using System.Collections.Generic;
using AutoMapper;
using EPAM_entity.Entities;
using EPAM_entity.Interfaces;

namespace EPAM_entity.Services
{
    public class SupplierService : ISupplierService
    {
        private IUnitOfWork _database;
        private IMapper _mapper;

        public SupplierService(IUnitOfWork uow, IMapper mapper)
        {
            _database = uow;
            _mapper = mapper;
        }

        public void CreateSupplier(SupplierDTO supplier)
        {
            var supplierEntity = _mapper.Map<Supplier>(supplier);
            _database.Suppliers.Add(supplierEntity);
            _database.Save();
        }

        public SupplierDTO GetSupplierById(int id)
        {
            var supplierEntity = _database.Suppliers.Get(id);
            var supplier = _mapper.Map<SupplierDTO>(supplierEntity);

            return supplier;
        }

        public IEnumerable<SupplierDTO> GetSuppliers()
        {
            var suppliersEntity = _database.Suppliers.GetAll();
            var suppliers = _mapper.Map<IEnumerable<SupplierDTO>>(suppliersEntity);

            return suppliers;
        }

        public IEnumerable<SupplierDTO> GetSuppliersByName(string name)
        {
            var suppliersEntity = _database.Suppliers.GetSuppliersWithName(name);
            var suppliers = _mapper.Map<IEnumerable<SupplierDTO>>(suppliersEntity);

            return suppliers;
        }

        public void Dispose()
        {
            _database.Dispose();
        }
    }
}
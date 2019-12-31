using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EPAM_entity.Entities;
using EPAM_entity.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuppliersController : ControllerBase
    {
        private ISupplierService _supplier;
        
        public SuppliersController(ISupplierService supplierService)
        {
            _supplier = supplierService;
        }
        
        
        [HttpGet]
        public ActionResult<IEnumerable<SupplierDTO>> Get()
        {
            IEnumerable<SupplierDTO> list = _supplier.GetSuppliers().ToList();
            return Ok(list);
        }
        
        [HttpGet("{id}")]
        public ActionResult<SupplierDTO> GetById(int id)
        {
            var item = _supplier.GetSupplierById(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }
        
        [HttpGet("{name}")]
        public ActionResult<SupplierDTO> GetById(string name)
        {
            var item = _supplier.GetSuppliersByName(name);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        public ActionResult Post(SupplierDTO supplier)
        {
            _supplier.CreateSupplier(supplier);

            var uri = Path.Combine(Request.Path.ToString(), Uri.EscapeUriString(supplier.Name));
            return Created(uri, supplier);
        }
        
    }
}
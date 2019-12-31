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
    public class ProductsController : ControllerBase
    {
        private IProductService _products;
        
        
        public ProductsController(IProductService productService)
        {
            _products = productService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductDTO>> Get()
        {
            var products = _products.GetProducts().ToList();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDTO> GetById(int id)
        {
            var item = _products.GetProductById(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }
        
        [HttpPost]
        public ActionResult Post(ProductDTO productDto)
        {
            _products.CreateProduct(productDto);

            var uri = Path.Combine(Request.Path.ToString(), Uri.EscapeUriString(productDto.ProductName));
            return Created(uri, productDto);
        }
        
        
    }
}
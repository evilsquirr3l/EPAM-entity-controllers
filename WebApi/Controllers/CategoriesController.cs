using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EPAM_entity.Entities;
using EPAM_entity.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private ICategoryService _category;
        
        public CategoriesController(ICategoryService categoryService)
        {
            _category = categoryService;
        }
        
        
        [HttpGet]
        public ActionResult<IEnumerable<CategoryDTO>> Get()
        {
            IEnumerable<CategoryDTO> list = _category.GetCategories();
            return Ok(list);
        }
        
        [HttpGet("{id}")]
        public ActionResult<CategoryDTO> GetById(int id)
        {
            var item = _category.GetCategoryById(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        public ActionResult Post(CategoryDTO categoryDTO)
        {
            _category.CreateCategory(categoryDTO);

            var uri = Path.Combine(Request.Path.ToString(), Uri.EscapeUriString(categoryDTO.Name));
            return Created(uri, categoryDTO);
        }
        
        
    }
}
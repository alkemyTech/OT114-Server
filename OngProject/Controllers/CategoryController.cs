using Microsoft.AspNetCore.Mvc;
using OngProject.Interfaces;
using OngProject.Models;
using OngProject.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService )
        {
            _categoryService = categoryService;
        }
                
        [HttpGet]
        public ActionResult<List<Category>> GetAll()
        {
            //var categories =  _categoryService.GetAll();
            //Replace here //
            var category = _categoryService.GetAll();
            if (category.Count == 0)
            {
                return NotFound();
            }

            return Ok(category);
        }
    }
}

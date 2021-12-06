using Microsoft.AspNetCore.Mvc;
using OngProject.Services.Interfaces;

namespace OngProject.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("/ObtenerCategorias")]
        public IActionResult Get()
        {
            var cate = _categoryService.GetAllEntities();
            if (cate == null)
            {
                return NotFound("La categoria no existe :(");
                
            }

            return Ok(cate);
        }

    }
}

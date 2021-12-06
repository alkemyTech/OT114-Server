using Microsoft.AspNetCore.Mvc;
using OngProject.Interfaces;
using OngProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using OngProject.ViewModels;

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
        [Route(template: "categorias")]
        public IActionResult Get()
        {

            var category = _categoryService.GetAllCategory();
            // var user = _context.Users.ToList();
            var categoryVM = new List<categoryVM>();

            foreach (var u in category)
            {
                categoryVM.Add(new categoryVM
                {
                    Id = u.Id,
                    Description=u.Description,
                    Name=u.Name
                });
            }

            return Ok(categoryVM);

        }
    }
}

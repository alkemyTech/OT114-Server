using Microsoft.AspNetCore.Mvc;
using OngProject.Interfaces;
using OngProject.Models;
using OngProject.Repositories;
using OngProject.ViewModels.Category;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<ActionResult<List<CategoryResponseListVM>>> GetAll()
        {
            try
            {
                var categories = await _categoryService.GetAll();
                var categoriesVM = new List<CategoryResponseListVM>();

                if (categories.Count == 0)
                {
                    return StatusCode(404);
                }

                foreach (var item in categories)
                {
                    CategoryResponseListVM tempCategory = new()
                    {
                        Name = item.Name
                    };
                    categoriesVM.Add(tempCategory);
                }
                return Ok(categoriesVM);
            }
            catch (System.Exception ex)
            {
                string error = ex.Message;
                return NoContent();
            }

        }

        [HttpGet]
        public async Task<ActionResult<CategoryResponseIdVM>> GetById(int id)
        {
            try
            {
                var category = await _categoryService.GetById(id);
                var categoryVM = new CategoryResponseIdVM()
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                    Image = category.Image,
                    deletedAt = category.deletedAt
                };

                if (categoryVM.Id == id)
                {
                    return categoryVM;
                }
                else
                {
                    return StatusCode(404);
                }
            }
            catch (System.Exception ex)
            {
                string error = ex.Message;
                return NoContent();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(CategoryRequestVM model)
        {
            Category NewCategory = new Category
            {
                Name = model.Name
            };
            var Newcat = await _categoryService.Insert(NewCategory);

            return Ok(Newcat);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Category categ)
        {
            var category = _categoryService.GetById(categ.Id);

            if (category == null)
                return NotFound($"La categoría con id {categ.Id} no existe.");

            var cat = await _categoryService.Update(categ);

            return Ok(cat);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var category = _categoryService.GetById(id);

            if (category == null)
                return NotFound($"La categoría con id {id} no existe.");

            _categoryService.Delete(id);

            return Ok("La categoría se borró correctamente.");
        }
    }
}
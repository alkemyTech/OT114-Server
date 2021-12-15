using Microsoft.AspNetCore.Authorization;
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

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<Category>>> GetAll()
        {
            try
            {
                var categories = await _categoryService.GetAll();
                var ListaNombres = new List<Category>();

                if (categories.Count == 0)
                {
                    return NoContent();
                }

                foreach (var item in categories)
                {
                    var tempName = new Category
                    {
                        Name = item.Name
                    };
                    ListaNombres.Add(tempName);
                }

                return ListaNombres;

            }
            catch (System.Exception ex)
            {
                string error = ex.Message;
                return NoContent();
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Category>> GetById(int id)
        {
            try
            {
                var category = await _categoryService.GetById(id);

                if (category.Id == id && category.deletedAt is not null)
                {
                    return category;
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
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Post(Category category)
        {
            Category NewCategory = new Category
            {
                Name = category.Name
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
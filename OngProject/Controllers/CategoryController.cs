using Microsoft.AspNetCore.Mvc;
using OngProject.Interfaces;
using OngProject.Models;
using OngProject.Repositories;
using System;
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
        public async Task<ActionResult<List<Category>>> GetAll()
        {
            var categories = await _categoryService.GetAll();
            if (categories.Count == 0)
            {
                return NotFound();
            }

            return Ok(categories);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Category cat)
        {
            var catetoadd = await _categoryService.Insert(cat);

            return Ok(catetoadd);
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
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _categoryService.Delete(id);
                return Ok("categoria borrada correctamente");
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}

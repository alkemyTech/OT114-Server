using Microsoft.AspNetCore.Authorization;
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
                string err = ex.Message;
                throw;
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Category>> GetById(int id)
        {
            try
            {
                var category = await _categoryService.GetById(id);

                if (category.deletedAt is null)
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
                string err = ex.Message;
                throw;
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Post(Category category)
        {
            //control de string hecho en la entidad category
            if (category.Name is null)
            {
                return StatusCode(404);
            }
            Category NewCategory = new Category
            {
                Name = category.Name
            };

            var Newcat = await _categoryService.Insert(NewCategory);

            return Ok(Newcat);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Category c)
        {
            var cate = _categoryService.GetById(c.Id);

            if ((cate == null) || (cate.Result.deletedAt != null))
                return NotFound($"La categoría con id {c.Id} no existe.");

            var category = await _categoryService.Update(c);

            return Ok(category);
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

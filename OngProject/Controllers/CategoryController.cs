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
        public async Task<ActionResult<List<Category>>> GetAll()
        {
            var members = await _categoryService.GetAll();
            if (members.Count == 0)
            {
                return NotFound();
            }

            return Ok(members);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Category mem)
        {
            var member = await _categoryService.Insert(mem);

            return Ok(member);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Category mem)
        {
            var m = _categoryService.GetById(mem.Id);

            if (m == null)
                return NotFound($"La categoría con id {mem.Id} no existe.");

            var member = await _categoryService.Update(mem);

            return Ok(member);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var member = _categoryService.GetById(id);

            if (member == null)
                return NotFound($"La categoría con id {id} no existe.");

            _categoryService.Delete(id);

            return Ok("La categoría se borró correctamente.");
        }
    }
}
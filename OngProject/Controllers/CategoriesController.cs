using Microsoft.AspNetCore.Mvc;
using OngProject.Entities;
using OngProject.Interfaces;
using OngProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly ICategoriesRepository _categoriesRepository;

        public CategoriesController(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }


        // GET: api/<CategoriesController>
        [HttpGet]
        [Route("Categories-List")]
        public IActionResult Get()
        {
            var Categories = _categoriesRepository.GetAllEntities();
            var CategoriesViewModel = new List<CategoriesResponseVM>();

            try
            {
                foreach (var cate in Categories)
                {
                    CategoriesResponseVM model = new()
                    {
                        Id = cate.Id,
                        Name = cate.Name,
                        Description = cate.Description,
                        Image = cate.Image,
                        TimeStamp = cate.TimeStamp
                    };
                    CategoriesViewModel.Add(model);
                }
                return Ok(CategoriesViewModel);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        // POST api/<CategoriesController>
        [HttpPost]
        public IActionResult Post(CategoriesRequestVM model)
        {
            try
            {
                Categories newCategory = new Categories
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                    Image = model.Image,
                    TimeStamp = model.TimeStamp
                };
                _categoriesRepository.Add(newCategory);
                return Ok(newCategory);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        // PUT api/<CategoriesController>
        [HttpPut]
        public IActionResult Put(CategoriesPutVM model)
        {
            try
            {
                //verificar que sea este metodo y no el de CategoryRepository -> getCategories()
                var categoryToEdit = _categoriesRepository.GetEntity(model.Id);
                if (categoryToEdit is null)
                {
                    return NotFound("La categoria buscada no existe");
                }
                else
                {
                    categoryToEdit.Name = model.Name;
                    categoryToEdit.Image = model.Image;
                    categoryToEdit.Description = model.Description;
                }
                _categoriesRepository.Update(categoryToEdit);
                return Ok(categoryToEdit);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                //verificar que sea este metodo y no el de CategoryRepository -> getCategories()
                var categoryToDelete = _categoriesRepository.GetEntity(id);

                if (categoryToDelete == null)
                {
                    return NotFound("La categoria buscada no existe");
                }
                else
                {
                    _categoriesRepository.Delete(id);

                    return Ok("Categoria eliminada");
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }
    }
}

﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OngProject.Interfaces;
using OngProject.Models;
using OngProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly int records = 10;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<Category>>> GetAll(int? pages)
        {

            var categories = await _categoryService.GetAll();
            var ListaNombres = new List<Category>();

            try
            {

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
                

            }
            catch (System.Exception ex)
            {
                string err = ex.Message;
                throw;
            }
            int _page = pages ?? 1;
            decimal totalRecords = ListaNombres.Count();
            int total_pages = Convert.ToInt32(Math.Ceiling(totalRecords / records));
            var query = ListaNombres.Skip((_page - 1) * records).Take(records).ToList();
            return Ok(new
            {

                pages = total_pages,
                records = query,
                current_page = _page
            });
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
            var cate = await _categoryService.GetById(c.Id);

            if ((cate == null) || (cate.deletedAt != null))
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

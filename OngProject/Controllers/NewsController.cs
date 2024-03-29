﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngProject.Models;
using OngProject.Services;
using OngProject.Services.Interfaces;
using OngProject.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("api/news")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;
        private readonly int records = 10;
        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }
        [HttpGet]
        public async Task<IActionResult> GetNews(int? pages)
        {
            int _page = pages ?? 1;
            var news = await _newsService.GetAll();
            decimal totalRecords = news.Count();
            int total_pages = Convert.ToInt32(Math.Ceiling(totalRecords / records));
            var query = news.Skip((_page - 1) * records).Take(records).ToList();
            return Ok(new
            {
                pages = total_pages,
                records = query,
                current_page = _page
            }
                );
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<News>> GetById(int id)
        {
            var news = await _newsService.GetById(id);

            if (news.DeletedAt != null)
            {
                return NotFound($"la novedad con id {id} no existe.");
            }

            return Ok(news);
        }

        [HttpPost]
        public async Task<ActionResult> Post(News n)
        {
            if (ModelState.IsValid)
            {
                var news = await _newsService.Insert(n);
                return Ok(news);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Put(News news)
        {
            var NewsUpdate = await _newsService.GetById(news.Id);

            if(NewsUpdate == null)
            {
                return NoContent();
            }

            NewsUpdate.Image = news.Image;
            NewsUpdate.Name = news.Name;
            NewsUpdate.Text = news.Text;

            try
            {
                if (ModelState.IsValid)
                {
                    await _newsService.Update(NewsUpdate);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return Ok(NewsUpdate);
        }
        [HttpDelete]
        [Route("{id}")]
        public  async Task<IActionResult> Delete(int id)
        {
            var news = await _newsService.Delete(id);
            if(news == null)
            {
                return NotFound("La novedad que intenta eliminar no existe");
            }
            
            try
            {                
                await _newsService.Delete(id);
            }
            catch (Exception)
            {

                throw;
            }

            return Ok("Se ha eliminado la novedad correctamente.");
        }
    }
}

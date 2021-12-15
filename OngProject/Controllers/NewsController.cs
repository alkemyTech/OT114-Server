using Microsoft.AspNetCore.Http;
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

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
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

            return news;
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
        [HttpDelete]
        [Route("{id}")]
        public  async Task<IActionResult> Delete(int id)
        {
            await  _newsService.GetById(id);
            
            if(id == 0)
            {
                return NotFound();
            }
            try
            {
                _newsService.Delete(id);
            }
            catch (Exception)
            {

                throw;
            }

            return Ok();
        }
    }
}
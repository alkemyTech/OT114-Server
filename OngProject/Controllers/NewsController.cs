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
    [ApiController]
    [Route("api/News")]
    public class NewsController : ControllerBase
    {

        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var news = _newsService.GetAllNews();
            return Ok(news);
        }

        [HttpGet]
        public async Task<ActionResult<News>> GetById(int id)
        {
            var news = await _newsService.GetIdNews(id);

            if (news == null)
            {
                return NotFound($"la news con id {id} no existe.");
            }

            return Ok(news);
        }

        [HttpPost]
        public async Task<IActionResult> Post(News news)
        {
            var CreateNews = await _newsService.InsertNews(news);
            return Ok(CreateNews);
        }

        [HttpPut]
        public async Task<IActionResult> Put(News news)
        {
            var searchNews = await _newsService.GetIdNews(news.Id);
            if(searchNews == null)
            {
                return NoContent();
            }
            await _newsService.UpdateNews(searchNews);
            if(searchNews == null)
            {
                return BadRequest();
            }
            return Ok(searchNews);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var news =  _newsService.GetIdNews(id);
            if (news==null) 
            {
                return NoContent();
            }
             _newsService.DeleteNews(id);
            return Ok();
        }
    }
}

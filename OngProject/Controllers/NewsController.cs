using Microsoft.AspNetCore.Mvc;
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
            var news = await _newsService.GetById();
            
            if (news.DeletedAt != null)
            {
                return NotFound($"la novedad con id {id} no existe.");
            }

            return Ok(news);
        }

   
    }
}

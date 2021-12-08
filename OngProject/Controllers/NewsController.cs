using Microsoft.AspNetCore.Mvc;
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
            var news = _newsService.GetAll();
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<News>> GetById(int id)
        {
            var news = await _newsService.GetById(id);

            if (news == null)
            {
                return NotFound($"la news con id {id} no existe.");
            }

            return Ok(news);
        }



    }
}

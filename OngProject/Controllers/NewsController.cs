using Microsoft.AspNetCore.Http;
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

        [HttpPost]
        public async Task<ActionResult> Post(News n)
        {
            if(ModelState.IsValid)
            {     
                var news = await _newsService.Insert(n);
                return Ok(news);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

    }
}

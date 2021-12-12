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
    }
}

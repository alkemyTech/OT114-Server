using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OngProject.Data;
using OngProject.Models;
using OngProject.Repositories;
using OngProject.Interfaces;
using Microsoft.EntityFrameworkCore;
using OngProject.Services.Interfaces;
using OngProject.Services;

namespace OngProject.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {

        }
    }


}

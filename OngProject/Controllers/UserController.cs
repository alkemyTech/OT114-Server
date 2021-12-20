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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;

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

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            var users = await _userService.GetAll();
            if (users.Count == 0)
            {
                return NotFound();
            }

            return Ok(users);
        }

        //[HttpPatch] //SIN TERMINAR
        //[Authorize(Roles = "User")]
        //public async Task<ActionResult<List<User>>> Patch(int id, JsonPatchDocument<User> patchDocument)
        //{
        //    var Updateus = await _userService.GetById(id);
        //    if (Updateus is null)
        //    {
        //        return BadRequest();
        //    }            
        //    patchDocument.ApplyTo(
        //    return Ok(await _userService.Update(Updateus));


        //}

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _userService.Delete(id);
                return Ok("usuario borrado correctamente");
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

    }
}

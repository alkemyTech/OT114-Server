using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OngProject.Models;
using OngProject.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Http;

namespace OngProject.Controllers
{
    [ApiController]
    [Route("api/users")]
    [Produces(contentType: "application/json")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        /// <summary>
        /// Get all Users in the system
        /// </summary>
        /// <returns>A list of Users</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET
        ///     {
        ///        "IdUser": 1,
        ///        "FirstName": "Juan",
        ///        "LastName" : "Gomez",
        ///        "Email" : "JuanGomez@gmail.com",
        ///        "Password" : "XXXX",
        ///        "Photo" : "Empty",
        ///        "roleId" : "idRoles",
        ///        "DeletedAt" : "null"
        ///        "MyToken" : "XXXX"
        ///        
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns a list of Users</response>
        /// <response code="401">Unauthorized. Unauthenticated user or wrong jwt token.</response>        
        /// <response code="403">If the user is prohibited from access</response>
        /// <response code="404">If the user don´t exist</response>
        /// <response code="500">Internal server error. An error occurred while processing your request.</response>
        [HttpGet]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            var users = await _userService.GetAll();
            if (users.Count == 0)
            {
                return NotFound();
            }

            return Ok(users);
        }


        /// <summary>
        /// Edit a User in the system
        /// </summary>
        /// <returns>Edited User</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PATCH
        ///     {
        ///        "IdUser": 1,
        ///        "FirstName": "Juan",
        ///        "LastName" : "Gomez",
        ///        "Email" : "JuanGomez@gmail.com",
        ///        "Password" : "XXXX",
        ///        "Photo" : "Empty",
        ///        "roleId" : "idRoles",
        ///        "DeletedAt" : "null"
        ///        
        ///     }
        ///
        /// </remarks>
        /// <response code="200">the user was edited successfully</response>
        /// <response code="401">Unauthorized. Unauthenticated user or wrong jwt token.</response>  
        /// <response code="403">If the user is prohibited from access</response>
        /// <response code="404">Unable to edit the user do not exist</response>
        [HttpPatch] //no lo probé
        [Authorize(Roles = "User")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<User>> Patch(int id, [FromBody] JsonPatchDocument<User> patchDocument)
        {
            var Updateus = await _userService.GetById(id);
            if (Updateus is null)
            {
                return BadRequest();
            }
            patchDocument.ApplyTo(Updateus, ModelState);
            return Ok(await _userService.Update(Updateus));


        }

        /// <summary>
        /// delete a User in the system
        /// </summary>
        /// <returns>deleted User</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE
        ///     {
        ///        "id": 1
        ///        
        ///     }
        ///
        /// </remarks>
        /// <response code="200">the User was deleted successfully</response>
        /// <response code="404">Unable to delete the user don´t exist</response>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngProject.Interfaces;
using OngProject.Models;
using OngProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    /// <summary>
    /// Controller for save, read, update or delete activities
    /// </summary>
    [Route("api/Activity")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        /// <summary>
        /// Gets a list of all activities
        /// </summary>
        /// <returns>All activities or an error</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET: api/Activity
        ///     {
        ///        "Id": 1,
        ///        "Name": "FFFF",
        ///        "Content" : "FFFF",
        ///        "Image": "img",
        ///        "deletedAt" : null
        ///     }
        ///
        /// </remarks>
        /// <response code="200">OK. Returns a list of all activities</response>
        /// <response code="401">Unauthorized. Unauthenticated user or wrong jwt token.</response>
        /// <response code="404">NotFound. Objects not found.</response>
        /// <response code="500">Internal server error. An error occurred while processing your request.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<Activity>>> GetAll()
        {
            var activities = await _activityService.GetAll();
            if (activities.Count == 0)
            {
                return NotFound();
            }

            return Ok(activities);
        }

        /// <summary>
        /// Creates an activity
        /// </summary>
        /// <returns>OK with the new object, or an error</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST: api/Activity
        ///     {
        ///        "Id": 1,
        ///        "Name": "FFFF",
        ///        "Content" : "FFFF",
        ///        "Image": "img",
        ///       
        ///     }
        ///
        /// </remarks>
        /// <response code="200">OK. Success, returns a new object.</response>
        /// <response code="204">NoContent. </response>
        /// <response code="400">BadRequest. Object not created, incorrect format.</response>
        /// <response code="401">Unauthorized. Unauthenticated user or wrong jwt token.</response>
        /// <response code="500">Internal server error. An error occurred while processing your request.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post(Activity activity)
        {
            var Postactivity = new Activity();

            
            if (string.IsNullOrEmpty(Postactivity.Content))
            {
                return NoContent();
            }

            if (string.IsNullOrEmpty(Postactivity.Name))
            {
                return NoContent();
            }
            
            try
            {
                if (ModelState.IsValid)
                {
                    Postactivity = await _activityService.Insert(activity);
                }

            }
            catch (Exception)
            {

                throw;
            }

            return Ok(Postactivity);
        }

        /// <summary>
        /// Updates an activity
        /// </summary>
        /// <returns>OK with updated object, or an error</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT: api/Activity
        ///     {
        ///        "Id": 1,
        ///        "Name": "FFFF",
        ///        "Content" : "FFFF",
        ///        "Image": "img",
        ///        
        ///     }
        ///
        /// </remarks>
        /// <response code="200">OK. Success, returns a new object.</response>
        /// <response code="400">BadRequest. Object not created, incorrect format.</response>
        /// <response code="401">Unauthorized. Unauthenticated user or wrong jwt token.</response>
        /// <response code="404">NotFound. Object not found.</response>
        /// <response code="500">Internal server error. An error occurred while processing your request.</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Put(Activity a)
        {
            var act = await _activityService.GetById(a.Id);

            if (act == null)
                return NotFound($"La actividad con id {a.Id} no existe.");

            var activity = await _activityService.Update(act);

            return Ok(activity);
        }

        /// <summary>
        /// Deletes an activity
        /// </summary>
        /// <returns>OK or an error</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     Delete: api/Activity/1
        ///     {
        ///        "Id": 1,
        ///        
        ///     }
        ///
        /// </remarks>
        /// <response code="200">OK. Success.</response>
        /// <response code="401">Unauthorized. Unauthenticated user or wrong jwt token.</response>
        /// <response code="404">NotFound. Object not found.</response>
        /// <response code="500">Internal server error. An error occurred while processing your request.</response>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int id)
        {
            var activity = _activityService.GetById(id);

            if (activity == null)
                return NotFound($"La actividad con id {id} no existe.");

            _activityService.Delete(id);

            return Ok("La actividad se borró correctamente.");
        }
    }
}

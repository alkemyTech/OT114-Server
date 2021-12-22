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
    [Route("api/Activity")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetAll()
        {
            var activities = await _activityService.GetAll();
            if (activities.Count == 0)
            {
                return NotFound();
            }

            return Ok(activities);
        }

        [HttpPost]
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

        [HttpPut]
        public async Task<ActionResult> Put(Activity a)
        {
            var act = await _activityService.GetById(a.Id);

            if (act == null)
                return NotFound($"La actividad con id {a.Id} no existe.");

            var activity = await _activityService.Update(act);

            return Ok(activity);
        }

        [HttpDelete]
        [Route("{id}")]
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

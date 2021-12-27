using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngProject.Models;
using OngProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(contentType: "application/json")]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        /// <summary>
        /// Get all Testimonials in the system
        /// </summary>
        /// <returns>A list of Testimonials</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET
        ///     {
        ///        "Id": 1,
        ///        "Name": "Item #1",
        ///        "Image" : "Empty",
        ///        "Content" : "AddAContent",
        ///        "DeletedAt" : "null"       
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns a list of Testimonials</response>
        /// <response code="404">If the Testimonial do not exist</response>
        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Testimonials>>> GetAll()
        {
            var testimonials = await _testimonialService.GetAll();
            if (testimonials.Count == 0)
            {
                return NotFound();
            }

            return Ok(testimonials);
        }

        /// <summary>
        /// Create a Testimonial in the system
        /// </summary>
        /// <returns>A new Testimonial</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST
        ///     {
        ///        "Id": 1,
        ///        "Name": "Item #1",
        ///        "Image" : "Empty",
        ///        "Content" : "AddAContent",
        ///        "DeletedAt" : "null"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns a list of Users</response>
        /// <response code="401">Unauthorized. Unauthenticated user or wrong jwt token.</response>        
        /// <response code="403">If the user is prohibited from access</response>
        /// <response code="404">If the testimonial don´t exist</response>
        /// <response code="500">Internal server error. An error occurred while processing your request.</response>
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post([FromBody] Testimonials testi)
        {
            var addTesti = new Testimonials
            {
                Name = testi.Name,
                Image = testi.Image,
                Content = testi.Content

            };

            if ((addTesti.Name == null) || (addTesti.Content == null))
            {
                return BadRequest("Los campos no pueden quedar vacios");
            }
            else
            {
                await _testimonialService.Insert(addTesti);
                return Ok(addTesti);
            }

        }

        /// <summary>
        /// Edit a Testimonial in the system
        /// </summary>
        /// <returns>Edited Testimonial</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT
        ///     {
        ///        "Id": 1,
        ///        "Name": "Item #1",
        ///        "Image" : "Empty",
        ///        "Content" : "AddAContent",
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns a list of Users</response>
        /// <response code="401">Unauthorized. Unauthenticated user or wrong jwt token.</response>        
        /// <response code="403">If the user is prohibited from access</response>
        /// <response code="404">If the testimonial don´t exist</response>
        /// <response code="500">Internal server error. An error occurred while processing your request.</response>
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Put(int id, Testimonials testimonials)
        {
            var testimonial = await _testimonialService.GetById(id); //traigo el ID 

            if ((testimonial == null) || (testimonial.DeletedAt != null)) {
                return NotFound($"El testimonio con id {id} no existe.");
            }
            else
            {
                testimonial.Name = testimonials.Name;
                testimonial.Content = testimonials.Content;
                testimonial.Image = testimonials.Image;

                var tes = _testimonialService.Update(testimonial);

                return Ok(tes);
            }

        }


        /// <summary>
        /// delete a Testimonial in the system
        /// </summary>
        /// <returns>deleted Testimonial</returns>
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
        /// <response code="200">Returns a list of Users</response>
        /// <response code="401">Unauthorized. Unauthenticated user or wrong jwt token.</response>        
        /// <response code="403">If the user is prohibited from access</response>
        /// <response code="404">If the testimonial don´t exist</response>
        /// <response code="500">Internal server error. An error occurred while processing your request.</response>
        [HttpDelete]
        [Authorize(Roles = "admin")]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
         {
              var testimonial = await _testimonialService.GetById(id);
              if (testimonial == null)
              return NotFound($"El testimonio con id {id} no existe.");
              _testimonialService.Delete(id);
              return Ok("El testimonio se borró correctamente.");
         }
    }
}

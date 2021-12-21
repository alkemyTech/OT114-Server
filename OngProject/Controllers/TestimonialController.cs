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
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Testimonials>>> GetAll()
        {
            var testimonials = await _testimonialService.GetAll();
            if (testimonials.Count == 0)
            {
                return NotFound();
            }

            return Ok(testimonials);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
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

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
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



        [HttpDelete]
        [Authorize(Roles = "admin")]
        [Route("{id}")]
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

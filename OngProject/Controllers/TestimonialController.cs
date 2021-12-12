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
        public async Task<ActionResult> Post(Testimonials testi)
        {
            var testiToAdd = await _testimonialService.Insert(testi);

            return Ok(testiToAdd);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Testimonials testi)
        {
            var testimonial = _testimonialService.GetById(testi.Id);

            if (testimonial == null)
                return NotFound($"El testimonio con id {testi.Id} no existe.");

            var tes = await _testimonialService.Update(testi);

            return Ok(tes);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var testimonial = _testimonialService.GetById(id);

            if (testimonial == null)
                return NotFound($"El testimonio con id {id} no existe.");

            _testimonialService.Delete(id);

            return Ok("El testimonio se borró correctamente.");
        }
    }
}
﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngProject.Models;
using OngProject.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    //[Authorize(Roles ="Administrador")]
    [ApiController]
    [Route("api/slides")]
    public class SlideController : ControllerBase
    {
        private readonly ISlideService _slideService;

        public SlideController(ISlideService slideService)
        {
            _slideService = slideService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Slide>>> GetAll()
        {
            var slides = await _slideService.GetAll();
            if (slides.Count == 0)
            {
                return NotFound();
            }

            return Ok(slides);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Slide>> GetById(int id)
        {
            var slide = await _slideService.GetById(id);
            if(slide == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Ok(slide);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Slide s)
        {
            var slide = new Slide();
            try
            {
                if (ModelState.IsValid)
                {
                    slide = await _slideService.Insert(s);
                }
                
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }

            
            return Ok(slide);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Slide mem)
        {
            var m = _slideService.GetById(mem.Id);

            if (m == null)
                return NotFound($"El Slide con id {mem.Id} no existe.");

            var slide = await _slideService.Update(mem);

            return Ok(slide);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var slide = _slideService.GetById(id);

            if (slide == null)
                return NotFound($"El Slide con id {id} no existe.");

            _slideService.Delete(id);

            return Ok("El Slide se borró correctamente.");
        }
    }
}

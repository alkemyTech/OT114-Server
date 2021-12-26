using Microsoft.AspNetCore.Http;
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
            var slide = await _slideService.Insert(s);

            return Ok(slide);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Slide slide)
        {
            var slideUpdate = await _slideService.GetById(slide.Id);

            if (slideUpdate == null || slideUpdate.DeletedAt != null)
            {
                return NoContent();
            }

            slideUpdate.ImageUrl = slide.ImageUrl;
            slideUpdate.Text = slide.Text;
            slideUpdate.Order = slide.Order;
            
            try
            {
                if (ModelState.IsValid)
                {
                    await _slideService.Update(slideUpdate);
                }

            }
            catch (System.Exception)
            {

                throw;
            }   

            

            return Ok(slideUpdate);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var slide = await _slideService.Delete(id);

            if (slide == null)
            {
                return NotFound($"El Slide con id {id} no existe.");
            }

            try
            {
               await _slideService.Delete(id);
            }
            catch (System.Exception)
            {

                throw;
            }

            return Ok("El Slide se borró correctamente.");
        }
    }
}

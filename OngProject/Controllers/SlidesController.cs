using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OngProject.Interfaces;
using OngProject.Models;
using OngProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    //[Authorize(Roles ="Administrador")]
    [ApiController]
    [Route("api/Slide")]
    public class SlidesController : ControllerBase
    {
        private readonly ISlideRepository _slideRepository;
        public SlidesController(ISlideRepository slideRepository)
        {
            _slideRepository = slideRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var slide = _slideRepository.GetAllEntities();
            if (!slide.Any())
            {
                return NotFound(new { 
                Status = "Error",
                Messege = "No se ha encontrado ningun Slide"
                });
            }
            return Ok(slide);
        }

        [HttpPost]
        public IActionResult Post(Slide slide)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _slideRepository.AddEntity(slide);
                }
            }
            catch (Exception)
            {

                return BadRequest();
            }
            
            
            return Ok(slide);
        }
        [HttpPut]
        public IActionResult Put(Slide slide)
        {
            var querySlide = _slideRepository.GetEntity(slide.Id);
            if (querySlide == null)
            {
                return NotFound($"El Slide con id {slide.Id} no existe.");
            }
            querySlide.ImageUrl = slide.ImageUrl;
            querySlide.Text = slide.Text;
            _slideRepository.UpdateEntity(querySlide);
            return Ok(querySlide);
        }
        [HttpDelete]
        [Route("{Id}")]
        public IActionResult Delete(int Id)
        {
            var querySlide = _slideRepository.GetEntity(Id);
            if (querySlide == null)
            {
                return NotFound($"El Slide con id {Id} no existe.");
            }
            _slideRepository.DeleteEntity(Id);
            return Ok($"El id {Id} se elimino correctamente");
        }
    }
}

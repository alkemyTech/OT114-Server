using Microsoft.AspNetCore.Mvc;
using OngProject.Context;
using OngProject.Entities;
using OngProject.Repositories;
using OngProject.Unit_Of_Work;
using OngProject.ViewModel.OrganizacionViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [ApiController]
    [Route(template: "api/[controller]")]
    public class OrganizacionesController : ControllerBase
    {

        private readonly IOrganizacionRepository _organizacionRepository;
        private readonly IUnitOfWork _unitOfWork;
        public OrganizacionesController(IOrganizacionRepository organizacionRepository, IUnitOfWork unitOfWork)
        {
            _organizacionRepository = organizacionRepository;
            _unitOfWork = unitOfWork;
             
        }
        [HttpGet]
        public IActionResult Get()
        {

            
            var OrganizacionesList = _unitOfWork.Organizacion.GetAllEntities();
            
            return Ok(OrganizacionesList);
        }
        [HttpPost]
        public IActionResult Post(OrganizacionPostVM  organizacionPostVM)
        {
            var organizacion = new Organizacion
            {
                Name = organizacionPostVM.Name,
                Image = organizacionPostVM.Image,
                Adress = organizacionPostVM.Adress,
                Phone = organizacionPostVM.Phone,
                Email = organizacionPostVM.Email,
                WelcomeText = organizacionPostVM.WelcomeText,
                AboutUsText = organizacionPostVM.AboutUsText,
                TimeStamps = organizacionPostVM.TimeStamps
            };
            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.Organizacion.Add(organizacion);
                }
                catch (Exception)
                {

                    return BadRequest();
                }
            }
            
            
            return Ok(organizacion);
        }
        [HttpPut]
        public IActionResult Put(Organizacion organizacion)
        {
            var organizacionExist = _unitOfWork.Organizacion.Get(organizacion.Id);
            if (organizacionExist == null)
            {
                return NotFound($"la organizacion con id {organizacion.Id} no existe.");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    organizacionExist.Name = organizacion.Name;
                    organizacionExist.Image = organizacion.Image;
                    organizacionExist.Adress = organizacion.Adress;
                    organizacionExist.Phone = organizacion.Phone;
                    organizacionExist.Email = organizacion.Email;
                    organizacionExist.WelcomeText = organizacion.WelcomeText;
                    organizacionExist.AboutUsText = organizacion.AboutUsText;
                    _unitOfWork.Organizacion.Update(organizacionExist);
                }
                catch (Exception)
                {

                    return BadRequest();
                }
            }

            return Ok(organizacionExist);
        }
        [HttpDelete]
        [Route("{Id}")]
        public IActionResult Delete(int Id)
        {
            var organizacion= _unitOfWork.Organizacion.Get(Id);
            if(organizacion == null)
            {
                return NotFound($"la organizacion con id {Id} no existe.");
            }
            _unitOfWork.Organizacion.Delete(Id);
            return Ok($"la organizacion {organizacion.Name} se elimino correctamente.");
        }
       
    }
}

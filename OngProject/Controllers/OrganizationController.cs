using Microsoft.AspNetCore.Mvc;
using OngProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        //ORGANIZACION INYECCION

        //CONTRUCTOR


        //GET api/<OrganizationController>/5
        //[HttpGet]
        //public async Task<ActionResult<Organization>> GetById(int id)
        //{
        //    try
        //    {
        //        var organization = await _organizationService.GetById(id);

        //        if (organization.Id == id)
        //        {
        //            return organization;
        //        }
        //        else
        //        {
        //            return StatusCode(404);
        //        }
        //    }
        //    catch (System.Exception ex)
        //    {
        //        string error = ex.Message;
        //        return NoContent();
        //    }
        //}
    }
}

using Microsoft.AspNetCore.Authorization;
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
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;

        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        [HttpGet]
        [Route("public")]
        [Authorize(Roles = "User")]
        public async Task<ActionResult<Organization>> GetById(int id)
        {
            try
            {
                var organization = await _organizationService.GetById(id);

                if (organization.deletedAt is null)
                {
                    return organization;
                }
                else
                {
                    return StatusCode(404);
                }
            }
            catch (System.Exception ex)
            {
                string err = ex.Message;
                throw;
            }
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Put(Organization _organization)
        {
            var organization = await _organizationService.GetById(_organization.Id);

            if ((organization == null) || (organization.deletedAt != null)) 
            {
                return NotFound($"La organization con id {_organization.Id} no existe.");
            }

            if (ModelState.IsValid)
            {
                var orga = await _organizationService.Update(_organization);
                return Ok(orga);
            }
            else
            {
                return NoContent();
            }
        }
    }
}

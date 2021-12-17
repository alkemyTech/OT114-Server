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

                if (organization.deletedAt is not null)
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
    }
}

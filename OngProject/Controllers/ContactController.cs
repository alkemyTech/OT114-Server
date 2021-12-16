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
    [ApiController]
    [Route("api/contacts")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        [Authorize(Roles ="admin")]
        public async Task<ActionResult<List<Contact>>> GetAll()
        {
            var contacts = await _contactService.GetAll();
            if (contacts.Count == 0)
            {
                return NotFound();
            }

            return Ok(contacts);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Contact con)
        {
            if ((con.Name == null) || (con.Email == null))
            {
                return BadRequest();
            }
            else
            {
                var contact = await _contactService.Insert(con);

                return Ok(contact);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _contactService.Delete(id);
                return Ok("contacto borrado correctamente");
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}

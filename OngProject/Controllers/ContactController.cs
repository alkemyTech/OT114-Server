using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngProject.Models;
using OngProject.Services;
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
        private readonly IMailService _mailService;

        public ContactController(IContactService contactService, IMailService mailservice)
        {
            _contactService = contactService;
            _mailService = mailservice;
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
            try
            {
                if ((con.Name == null) || (con.Email == null))
                {
                    return BadRequest("Debe ingresar nombre y email.");
                }
                else
                {
                    var contact = await _contactService.Insert(con);
                    await _mailService.SendNotification(contact.Email);
                    return Ok(contact);
                }
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
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

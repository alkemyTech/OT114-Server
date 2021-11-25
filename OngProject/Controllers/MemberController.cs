using Microsoft.AspNetCore.Mvc;
using OngProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MemberController : ControllerBase
    {
        private readonly IMemberRepository _memberRepository;
        public MemberController(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        [HttpGet]
        [Route("members")]
        public IActionResult GetAll()
        {
            var members = _memberRepository.GetMembers();

            if (!members.Any())
            {
                return NoContent();
            }

            var listado = members.Select(x => new { x.Name, x.Image}).ToList();

            return Ok(listado);
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult Put()
        {
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var member = _memberRepository.GetMember(id);

            if (member == null)
                return NotFound($"el miembro con id {id} no existe.");

            _memberRepository.Delete(id);

            return Ok("el miembro se borró correctamente.");
        }

    }
}

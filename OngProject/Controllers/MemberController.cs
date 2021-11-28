using Microsoft.AspNetCore.Mvc;
using OngProject.Entities;
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
        public IActionResult Post(Member postMember)
        {
            var _postMember = new Member
            {
                Name = postMember.Name,
                FacebookUrl = postMember.FacebookUrl,
                InstagramUrl = postMember.InstagramUrl,
                LinkedinUrl = postMember.LinkedinUrl,
                Image = postMember.Image,
                Description = postMember.Description
            };

            _memberRepository.Insert(_postMember);

            return Ok(_postMember);
        }

        [HttpPut]
        public IActionResult Put(Member putMember)
        {
            var _putMember = _memberRepository.GetById(putMember.Id);

            if (_putMember == null)
                return NotFound($"el miembro con id {_putMember.Id} no existe.");

            _putMember.Name = putMember.Name;
            _putMember.FacebookUrl = putMember.FacebookUrl;
            _putMember.InstagramUrl = putMember.InstagramUrl;
            _putMember.LinkedinUrl = putMember.LinkedinUrl;
            _putMember.Image = putMember.Image;
            _putMember.Description = putMember.Description;

            _memberRepository.Update(_putMember);

            return Ok(_putMember);
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

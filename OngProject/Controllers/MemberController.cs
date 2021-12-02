using Microsoft.AspNetCore.Mvc;
using OngProject.Models;
using OngProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("api/members")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Member>>> GetAll()
        {
            var members = await _memberService.GetAll();
            if (members.Count == 0)
            {
                return NotFound();
            }

            return Ok(members);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Member mem)
        {
            var member = await _memberService.Insert(mem);

            return Ok(member);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Member mem)
        {
            var m = _memberService.GetById(mem.Id);

            if (m == null)
                return NotFound($"el miembro con id {mem.Id} no existe.");

            var member = await _memberService.Update(mem);

            return Ok(member);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var member = _memberService.GetById(id);

            if (member == null)
                return NotFound($"el miembro con id {id} no existe.");

            await _memberService.Delete(id);

            return Ok("el miembro se borró correctamente.");
        }



    }
}

using Microsoft.AspNetCore.Mvc;
using OngProject.Models;
using OngProject.Services.Interfaces;
using System;
using System.Collections.Generic;
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
        public async Task<ActionResult> Put(Member m)
        {
            var mem = _memberService.GetById(m.Id);

            if ((mem == null) || (mem.Result.DeletedAt != null))
                return NotFound($"El Miembro con id {m.Id} no existe.");

            var member = await _memberService.Update(m);

            return Ok(member);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _memberService.Delete(id);
                return Ok("miembro borrado correctamente");
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}

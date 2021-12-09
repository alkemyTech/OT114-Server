using Microsoft.AspNetCore.Mvc;
using OngProject.Models;
using OngProject.Services.Interfaces;
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
        public async Task<ActionResult> Put(Member mem)
        {
            var m = _memberService.GetById(mem.Id);

            if (m == null)
                return NotFound($"El Miembro con id {mem.Id} no existe.");

            var member = await _memberService.Update(mem);

            return Ok(member);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var member = await _memberService.Delete(id);

            if (member.DeletedAt != null)
                return NotFound($"El Miembro con id {id} no existe.");
            
            else
            return Ok("El Miembro se borró correctamente.");
        }
    }
}

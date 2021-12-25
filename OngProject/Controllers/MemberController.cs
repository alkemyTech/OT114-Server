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
    [Route("api/members")]
    [ApiController]
    [Produces(contentType:"application/json")]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        /// <summary>
        /// Get all members in the system
        /// </summary>
        /// <returns>A list of members</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET
        ///     {
        ///        "id": 1,
        ///        "Name": "Item #1",
        ///        "FacebookUrl" : "www.facebook.com/Example",
        ///        "InstagramUrl" : "www.instagram.com/Example",
        ///        "LinkedinUrl" : "www.Linkedin.com/Example",
        ///        "Image" : "Empty",
        ///        "Description" : "AddADescriptionHere",
        ///        "DeletedAt" : "null"
        ///        
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns a list of members</response>
        /// <response code="404">If the members do not exist</response>

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Member>>> GetAll()
        {
            var members = await _memberService.GetAll();
            if (members.Count == 0)
            {
                return NotFound();
            }

            return Ok(members);
        }

        /// <summary>
        /// Create a member in the system
        /// </summary>
        /// <returns>A new Member</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST
        ///     {
        ///        "id": 1,
        ///        "Name": "Item #1",
        ///        "FacebookUrl" : "www.facebook.com/Example",
        ///        "InstagramUrl" : "www.instagram.com/Example",
        ///        "LinkedinUrl" : "www.Linkedin.com/Example",
        ///        "Image" : "Empty",
        ///        "Description" : "AddADescriptionHere"
        ///        
        ///     }
        ///
        /// </remarks>
        /// <response code="201">the member was created successfully</response>
        /// <response code="400">Unable to create the member  due to validation error</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post(Member mem)
        {
            if ((string.IsNullOrEmpty(mem.Name)) || (mem.Name.All(char.IsDigit)))
            {
                return BadRequest();
            }
            else
            {
                var member = await _memberService.Insert(mem);
                return Ok(member);
            }  
        }

        /// <summary>
        /// Edit a member in the system
        /// </summary>
        /// <returns>Edited Member</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT
        ///     {
        ///        "id": 1,
        ///        "Name": "Item #1",
        ///        "FacebookUrl" : "www.facebook.com/Example",
        ///        "InstagramUrl" : "www.instagram.com/Example",
        ///        "LinkedinUrl" : "www.Linkedin.com/Example",
        ///        "Image" : "Empty",
        ///        "Description" : "AddADescriptionHere"
        ///        
        ///     }
        ///
        /// </remarks>
        /// <response code="200">the member was edited successfully</response>
        /// <response code="404">Unable to edit the member do not exist</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Put(Member m)
        {
            var mem = _memberService.GetById(m.Id);

            if ((mem == null) || (mem.Result.DeletedAt != null))
                return NotFound();

            var member = await _memberService.Update(m);

            return Ok(member);
        }
        /// <summary>
        /// delete a member in the system
        /// </summary>
        /// <returns>deleted Member</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE
        ///     {
        ///        "id": 1
        ///        
        ///     }
        ///
        /// </remarks>
        /// <response code="200">the member was deleted successfully</response>
        /// <response code="404">Unable to delete the member do not exist</response>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _memberService.Delete(id);
                return Ok();
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}

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
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentsService _commentsService;

        public CommentsController(ICommentsService commentsService)
        {
            _commentsService = commentsService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")] //solo podrá ver todos los comentarios un administrador
        public async Task<ActionResult<List<Comments>>> GetAll()
        {
            var comments = await _commentsService.GetAll();
            if (comments.Count == 0)
            {
                return NotFound();
            }

            return comments;


        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Post([FromBody] Comments comments)
        {
            if ((comments.UserId == null) || (comments.Body == null) || (comments.NewsId == null))
            {
                return BadRequest();
            }
            else
            {
                var comment = new Comments
                {
                    UserId = comments.UserId,
                    Body = comments.Body,
                    NewsId = comments.NewsId

                };
                await _commentsService.Insert(comment);
                return Ok(comment);

            }            
            
        }

        [HttpPut]
        [Authorize(Roles = "Admin,User")] //solo podria actualizar un comentario el creador del comentario o un administrador
        public async Task<ActionResult> Put([FromBody] Comments comments)
        {
            var UpdateCom = await _commentsService.GetById(comments.Id); //traigo el ID del comentario
            if ((comments == null) || (comments.DeletedAt != null)) //chequeo que exista o que no este borrado
            {
                return BadRequest("el comentario no existe");
            };  
            
            var ObtenerUserID = new Comments //creo una variable para obtener el USERID
            {
                UserId = UpdateCom.UserId
            };

            if (comments.UserId == ObtenerUserID.UserId) //comparo el USERID 
            {
                UpdateCom.Body = comments.Body;  
                await _commentsService.Update(UpdateCom); //se modifica el campo body y se actualiza
                return Ok(UpdateCom);
            }
            else
            {
                return BadRequest();
            }          


        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var comment = await _commentsService.Delete(id);

            if (comment.DeletedAt != null)
                return NotFound("El Comentario  no existe.");

            else
                return Ok("El Comentario se eliminó correctamente.");

        }
    }
}

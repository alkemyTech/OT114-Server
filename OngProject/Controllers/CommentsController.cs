using Microsoft.AspNetCore.Authorization;
using OngProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OngProject.Services.Interfaces;
using OngProject.ViewModels;
using System.Linq;

namespace OngProject.Controllers
{
    [Route("api[controller]")]
    [ApiController]
    public class CommentsController
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
            
            
            return comments.OrderBy(x => x.CreatedDate).ToList(); //falta probar, deberia ordenar por fecha

            
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Post([FromBody] PostComments postComments)
        {            
            var comment = new Comments
            {
                UserId = postComments.UserId,
                Body = postComments.Body,
                NewsId = postComments.NewsId
                
            };
            await _commentsService.Insert(comment);
            return Ok(postComments);
        }

        [HttpPut]
        [Authorize(Roles = "Admin,User")] //solo podria actualizar un comentario el creador del comentario o un administrador
        public async Task<ActionResult> Put(int id, [FromBody] PutComment putComment)
        {
            var com = _commentsService.GetById(putComment.Id);

            if (com == null)
                return NotFound("El comentario no existe.");

            var comment = await _commentsService.Update(putComment);

            return Ok(comment);
        }

        //[HttpDelete]
        //[Route("{id}")]
        //public async Task<ActionResult> Delete(int id)
        //{
            
        //}
    }
}

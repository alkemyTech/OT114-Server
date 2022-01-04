using Microsoft.EntityFrameworkCore;
using OngProject.Data;
using OngProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Repositories
{
    public class CommentsRepository : BaseRepository<Comments, ONGDBContext>
    {
        private readonly ONGDBContext _context;
        public CommentsRepository(ONGDBContext context) : base(context)
        {
           _context = context;
        }

        public async override Task<List<Comments>> GetAll()
        {
            var ComActive = _context.Comments.Where(c => c.DeletedAt == null)
                                             .OrderBy(x => x.CreatedDate) //falta probar, deberia ordenar por fecha
                                             .Select(x => x.Body); //se crea una lista con todos los comentarios que tengan el campo DeletedAt nulo
            return (List<Comments>)ComActive; //no lo probé
        }
        public async override Task<Comments> Delete(int id)
        {
            Comments comment =await _context.FindAsync<Comments>(id);
            if ((comment == null)|| (comment.DeletedAt != null))
            {
                throw new Exception("el comentario no existe");
            }
            
            else
            {
               comment.DeletedAt = DateTime.Now;
               _context.Attach(comment);
               _context.Entry(comment).State = EntityState.Modified;
              await _context.SaveChangesAsync();
               return comment;
            }
        }   
         
    }
}

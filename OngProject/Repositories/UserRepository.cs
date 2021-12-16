using OngProject.Models;
using OngProject.Data;
using System;
using Microsoft.EntityFrameworkCore;

namespace OngProject.Repositories
{
    public class UserRepository : BaseRepository<User, ONGDBContext>
    {
        private readonly ONGDBContext _context;
        public UserRepository(ONGDBContext context) : base(context)
        {
            _context = context;
        }
        public override User Delete(int id)
        {
            User usuario = _context.Find<User>(id);

            if ((usuario.DeletedAt != null) || (usuario == null))
            {
                throw new Exception("el usuario no existe");
            }
            else
            {
                usuario.DeletedAt = DateTime.Now;
                _context.Attach(usuario);
                _context.Entry(usuario).State = EntityState.Modified;
                _context.SaveChanges();
                return usuario;
            }
        }
    }
}

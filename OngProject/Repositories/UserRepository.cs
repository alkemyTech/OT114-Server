using OngProject.Models;
using OngProject.Data;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace OngProject.Repositories
{
    public class UserRepository : BaseRepository<User, ONGDBContext>
    {
        private readonly ONGDBContext _context;
        public UserRepository(ONGDBContext context) : base(context)
        {
            _context = context;
        }

        public override List<User> GetAll()
        {
            var UserActive = _context.Users.Where(c => c.DeletedAt == null);
            return (List<User>)UserActive; //no lo probé
        }

        public override User Delete(int id)
        {
            User usuario = _context.Find<User>(id);

            if ((usuario == null) || (usuario.DeletedAt != null))
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

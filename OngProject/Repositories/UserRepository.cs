using OngProject.Models;
using OngProject.Data;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Repositories
{
    public class UserRepository : BaseRepository<User, ONGDBContext>
    {
        private readonly ONGDBContext _context;
        public UserRepository(ONGDBContext context) : base(context)
        {
            _context = context;
        }

        public async override Task<List<User>> GetAll()
        {
            var UserActive =await _context.Users.Where(c => c.DeletedAt == null).ToListAsync();
            return (UserActive); //no lo probé
        }

        public async override Task<User> Delete(int id)
        {
            User usuario =await _context.FindAsync<User>(id);

            if ((usuario == null) || (usuario.DeletedAt != null))
            {
                throw new Exception("el usuario no existe");
            }
            else
            {
                usuario.DeletedAt = DateTime.Now;
                _context.Attach(usuario);
                _context.Entry(usuario).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return usuario;
            }
        }
    }
}

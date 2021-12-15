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
            User user = _context.Find<User>(id);
            if (user.DeletedAt == null)
                user.DeletedAt = DateTime.Now;
            _context.Attach(user);
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
            return user;
        }
    }
}

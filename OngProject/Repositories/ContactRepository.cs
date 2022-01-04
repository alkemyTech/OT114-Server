using Microsoft.EntityFrameworkCore;
using OngProject.Data;
using OngProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Repositories
{
    public class ContactRepository : BaseRepository<Contact, ONGDBContext>
    {
        private readonly ONGDBContext _context;
        public ContactRepository(ONGDBContext context) : base(context)
        {
            _context = context;
        }
        public async override Task<List<Contact>> GetAll()
        {
            return await DbSet.Where(c => c.DeletedAt == null).ToListAsync();
        }
        public async override Task<Contact> Delete(int id)
        {
            Contact contact =await _context.FindAsync<Contact>(id);

            if ((contact == null) || (contact.DeletedAt != null))
            {
                throw new Exception("el contacto no existe");
            }
            else
            {
                contact.DeletedAt = DateTime.Now;
                _context.Attach(contact);
                _context.Entry(contact).State = EntityState.Modified;
               await _context.SaveChangesAsync();
                return contact;
            }
        }
    }
}
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
        public override List<Contact> GetAll()
        {
            return _context.Contacts.Where(c => c.DeletedAt == null).ToList();
        }
        public override Contact Delete(int id)
        {
            Contact contact = _context.Find<Contact>(id);

            if ((contact == null) || (contact.DeletedAt != null))
            {
                throw new Exception("el contacto no existe");
            }
            else
            {
                contact.DeletedAt = DateTime.Now;
                _context.Attach(contact);
                _context.Entry(contact).State = EntityState.Modified;
                _context.SaveChanges();
                return contact;
            }
        }
    }
}
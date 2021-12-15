using OngProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Services.Interfaces
{
    public interface IContactService
    {
        Task<List<Contact>> GetAll();
        Task<Contact> GetById(int id);
        Task<Contact> Insert(Contact contact);
        Task<Contact> Delete(int id);
        Task<Contact> Update(Contact contact);
    }
}

using OngProject.Models;
using OngProject.Services.Interfaces;
using OngProject.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Services
{
    public class ContactService : IContactService
    {
        private readonly UOW _unitOfWork;
        public ContactService(UOW unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Contact>> GetAll()
        {
            var contact = _unitOfWork.ContactRepository.GetAll();
            return contact;
        }
        public async Task<Contact> GetById(int id)
        {
            var contact = _unitOfWork.ContactRepository.GetById(id);
            return contact;
        }
        public async Task<Contact> Insert(Contact con)
        {
            var contact = _unitOfWork.ContactRepository.Add(con);
            return contact;
        }
        public async Task<Contact> Delete(int id)
        {
            var contact = _unitOfWork.ContactRepository.Delete(id);
            return contact;
        }
        public async Task<Contact> Update(Contact con)
        {
            var contact = _unitOfWork.ContactRepository.Update(con);
            return contact;
        }
    }
}

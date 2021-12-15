using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OngProject.Interfaces;
using OngProject.Models;
using OngProject.Repositories;
using OngProject.Data;
using OngProject.Services.Interfaces;
using OngProject.UnitOfWork;

namespace OngProject.Services
{
    public class UserService : IUserService
    {
        private readonly UOW _unitOfWork;
        public UserService(UOW unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<User>> GetAll()
        {
            var user = _unitOfWork.UserRepository.GetAll();
            return user.ToList();
        }
        public async Task<User> GetById(int id)
        {
            var user = _unitOfWork.UserRepository.GetById(id);
            return user;
        }
        public async Task<User> Insert(User u)
        {
            var user = _unitOfWork.UserRepository.Add(u);
            return user;
        }
        public async Task<User> Delete(int id)
        {
            var user = _unitOfWork.UserRepository.Delete(id);
            return user;
        }
        public async Task<User> Update(User u)
        {
            var user = _unitOfWork.UserRepository.Update(u);
            return user;
        }
    }
}

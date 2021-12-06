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
    public class UserService : BaseRepository<User, ONGDBContext>, IUserService
    {
        private readonly UOW _unitOfWork;



        public UserService(ONGDBContext dbContext) : base(dbContext)
        {

        }

        public UserService(UOW unitOfWork, ONGDBContext dbContext) : base(dbContext)
        {
            _unitOfWork = unitOfWork;
        }

        public User AddUser(User user)
        {
            return Add(user);
        }

        public List<User> GetAllUsers()
        {
            return GetAllEntities();
        }

        public User GetUser(User user)
        {
            return Get(user.IdUser);
        }

        public User UpdateUser(User user)
        {
            return Update(user);
        }
    }
}

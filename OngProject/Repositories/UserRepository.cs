using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OngProject.Models;
using OngProject.Data;
using OngProject.Interfaces;
using OngProject.Repositories;
using OngProject.Services.Interfaces;

namespace OngProject.Repositories
{
    public class UserRepository : BaseRepository<User, ONGDBContext>, IUserService
    {
        public UserRepository(ONGDBContext dbContext) : base(dbContext)
        {

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
            return Get(user.Id);
        }

        public User UpdateUser(User user)
        {
            return Update(user);
        }
    }
}

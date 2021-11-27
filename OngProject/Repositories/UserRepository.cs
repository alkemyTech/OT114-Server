using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OngProject.Entities;
using OngProject.Context;
using OngProject.Interfaces;
using OngProject.Repositories;

namespace OngProject.Repositories
{
    public class UserRepository : BaseRepository<User, OngContext>, IUserRepository
    {
        public UserRepository(OngContext dbContext) : base(dbContext)
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

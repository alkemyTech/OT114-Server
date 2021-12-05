using OngProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Services.Interfaces
{
    public interface IUserService : IService<User>
    {
        User AddUser(User user);
        List<User> GetAllUsers();
        User GetUser(User user);
        User UpdateUser(User user);
    }
}

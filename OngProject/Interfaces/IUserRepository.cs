using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OngProject.Entities;

namespace OngProject.Interfaces
{
    public interface IUserRepository: IRepository<User>
    {

        User AddUser(User user);
        List<User> GetAllUsers();
        User GetUser(User user);
        User UpdateUser(User user);



    }
}

using OngProject.Models;
using System.Collections.Generic;

namespace OngProject.Services.Interfaces
{
    public interface IRolesService 
    {
        Roles GetById(int id);
        List<Roles> GetRoles();
        Roles AddRoles(Roles roles);        
        Roles UpdateRoles(Roles roles);
        Roles DeleteRoles(int id);
    }
}

using OngProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Services.Interfaces
{
    public interface IRolesService 
    {
        Task<Roles> GetById(int id);
        Task<List<Roles>> GetRoles();
        Task<Roles> AddRoles(Roles roles);        
        Task<Roles> UpdateRoles(Roles roles);
        Task<Roles> DeleteRoles(int id);
    }
}

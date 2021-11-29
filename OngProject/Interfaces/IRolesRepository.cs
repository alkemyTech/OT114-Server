using ChallengeAcceleration.Repositories;
using OngProject.Entities;
using System.Collections.Generic;

namespace OngProject.Repositories
{
    public interface IRolesRepository : IBaseRepository<Roles>
    {
        Roles GetRole(int id);
        List<Roles> GetRoles();

      
    }
}
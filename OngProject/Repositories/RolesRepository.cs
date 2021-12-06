using OngProject.Data;
using OngProject.Models;
using OngProject.Services.Interfaces;
using System.Collections.Generic;

namespace OngProject.Repositories
{
    public class RolesRepository : BaseRepository<Roles, ONGDBContext>, IRolesService
    {

        public RolesRepository(ONGDBContext dbContext) : base(dbContext)
        {
        }

        public Roles AddRoles(Roles roles)
        {
            return Add(roles);
        }

        public Roles DeleteRoles(int id)
        {
            return Delete(id);
        }

        public Roles GetById(int id)
        {
            return Get(id);
        }

        public List<Roles> GetRoles()
        {
            return GetAllEntities();
        }

        public Roles UpdateRoles(Roles roles)
        {
            return Update(roles);
        }
    }

}


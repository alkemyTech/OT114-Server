using ChallengeAcceleration.Repositories;
using Microsoft.EntityFrameworkCore;
using OngProject.Context;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Repositories
{
    public class RolesRepository : BaseRepository<Roles, OngContext>, IRolesRepository
    {
        public RolesRepository(OngContext dbContext) : base(dbContext)
        {
        }

        public Roles GetRole(int id)
        {
            return DbSet.FirstOrDefault(x => x.Id == id);
        }

        public List<Roles> GetRoles()
        {
            return DbSet.ToList();
        }


    }
}

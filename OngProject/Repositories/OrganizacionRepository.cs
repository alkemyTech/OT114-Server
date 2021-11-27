using OngProject.Context;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Repositories
{
    public class OrganizacionRepository : BaseRepository<Organizacion, OngContext>, IOrganizacionRepository
    {
        public OrganizacionRepository(OngContext dbContext)
            : base(dbContext)
        {

        }
    }
}

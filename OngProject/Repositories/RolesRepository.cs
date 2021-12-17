using OngProject.Data;
using OngProject.Models;

namespace OngProject.Repositories
{
    public class RolesRepository : BaseRepository<Roles, ONGDBContext>
    {
        public RolesRepository(ONGDBContext dbContext) : base(dbContext)
        {
        }


    }
}




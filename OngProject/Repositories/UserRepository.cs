using OngProject.Models;
using OngProject.Data;

namespace OngProject.Repositories
{
    public class UserRepository : BaseRepository<User, ONGDBContext>
    {
        public UserRepository(ONGDBContext dbContext) : base(dbContext)
        {
        }
    }
}

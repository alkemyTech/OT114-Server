using OngProject.Data;
using OngProject.Models;

namespace OngProject.Repositories
{
    public class CommentsRepository : BaseRepository<Comments, ONGDBContext>
    {
        public CommentsRepository(ONGDBContext dbContext) : base(dbContext)
        {
        }        
    }
}

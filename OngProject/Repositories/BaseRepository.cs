using Microsoft.EntityFrameworkCore;
using OngProject.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Repositories
{
    public class BaseRepository<T> where T : class
    {
        protected readonly ONGDBContext _context;
        protected readonly DbSet<T> _model;

        public BaseRepository(ONGDBContext context)
        {
            _context = context;
            _model = context.Set<T>();
        }

        #region Public Methods

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _model.ToListAsync();
        }
		
		#endregion
    }
}

using Microsoft.EntityFrameworkCore;
using OngProject.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OngProject.Services.Interfaces;

namespace OngProject.Repositories
{
    public abstract class BaseRepository<TEntity, TContext>
      where TEntity : class
      where TContext : DbContext

    {
        private readonly TContext _dbContext;
        private DbSet<TEntity> _dbSet;
        protected DbSet<TEntity> DbSet
        {
            get { return _dbSet ??= _dbContext.Set<TEntity>(); }
        }

        protected BaseRepository(TContext dbContext)
        {
            _dbContext = dbContext;

        }

        public async virtual Task<List<TEntity>> GetAll()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async virtual Task<TEntity> GetById(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> Add(TEntity entity)
        {
          await  _dbContext.Set<TEntity>().AddAsync(entity);
          await  _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
             _dbContext.Attach(entity); //traquea una entidad - toman la entidad
            _dbContext.Entry(entity).State = EntityState.Modified; //traquea los cambios
           await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async virtual Task<TEntity> Delete(int id)
        {
            TEntity entity = await _dbContext.FindAsync<TEntity>(id);
             _dbContext.Remove(entity);
            return entity;

        }		
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeAcceleration.Repositories
{
    public abstract class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity> 
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

        public List<TEntity> GetAllEntities() //repo para mostrar
        {
            return _dbContext.Set<TEntity>().ToList();
        }
        public TEntity GetEntity(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }
        public TEntity Add(TEntity entity) //repositorio para añadir
        {
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public TEntity Update(TEntity entity) //actualizar 
        {
            _dbContext.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return entity;
        }

        public void Delete(int id) //Borrar
        {
            var entityToDelete = _dbContext.Find<TEntity>(id);
            _dbContext.Remove(entityToDelete);
            _dbContext.SaveChanges();
        }
    }
}

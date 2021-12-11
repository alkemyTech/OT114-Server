﻿using Microsoft.EntityFrameworkCore;
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


        protected BaseRepository(TContext dbContext)
        {
            _dbContext = dbContext;

        }

        public List<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);

        }

        public TEntity Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            _dbContext.Attach(entity); //traquea una entidad - toman la entidad
            _dbContext.Entry(entity).State = EntityState.Modified; //traquea los cambios
            _dbContext.SaveChanges();
            return entity;
        }

        public virtual TEntity Delete(int id)
        {
            TEntity entity = _dbContext.Find<TEntity>(id);
            _dbContext.Remove(entity);
            return entity;

        }		
    }
}

﻿using Microsoft.EntityFrameworkCore;
using OngProject.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace OngProject.Repositories
{
    public abstract class BaseRepository<TEntity, TContext> : IService<TEntity>
            where TEntity : class
            where TContext : DbContext
    {
        private readonly TContext _dbContext;


        protected BaseRepository(TContext dbContext)
        {
            _dbContext = dbContext;

        }

        public List<TEntity> GetAllEntities()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public TEntity Get(int id)
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

        public TEntity Delete(int id)
        {
            TEntity entity = _dbContext.Find<TEntity>(id);
            _dbContext.Remove(entity);
            //_dbContext.SaveChanges(); En esta parte se implementaria el softdelete
            return entity;

        }

    }
}


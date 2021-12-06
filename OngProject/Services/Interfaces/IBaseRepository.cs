using System.Collections.Generic;

namespace OngProject.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity AddEntity(TEntity entity);
        void DeleteEntity(int id);
        List<TEntity> GetAllEntities();
        TEntity GetEntity(int id);
        TEntity UpdateEntity(TEntity entity);
    }
}
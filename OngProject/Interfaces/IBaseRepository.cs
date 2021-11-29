using System.Collections.Generic;

namespace ChallengeAcceleration.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        List<TEntity> GetAllEntities();
        TEntity GetEntity(int id);
        TEntity Add(TEntity entity);            
        TEntity Update(TEntity entity);
        void Delete(int id);
    }
}
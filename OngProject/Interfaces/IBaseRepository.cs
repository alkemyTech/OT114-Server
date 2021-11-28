using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        List<TEntity> GetAllEntities();
        TEntity GetById(int id);
        TEntity Insert(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(int id);

    }
}

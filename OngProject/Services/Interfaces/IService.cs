using System.Collections.Generic;

namespace OngProject.Services.Interfaces
{
    public interface IService<T> where T : class
    {
        public List<T> GetAllEntities();
        public T Get(int id);
        public T Add(T entity);
        public T Update(T entity);
        public T Delete(int id);
    }
}

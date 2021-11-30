using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Interfaces
{
    public interface IBaseRepository<Entity> where Entity : class
    {
        public List<Entity> GetAllEntities();
        Entity GetEntity(int id);
        Entity Add(Entity entity);
        Entity Update(Entity entity);
        void SoftDelete(Entity entity);
        void Delete(int id);
    }
}

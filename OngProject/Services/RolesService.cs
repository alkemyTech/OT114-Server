using OngProject.Data;
using OngProject.Models;
using OngProject.Repositories;
using OngProject.Services.Interfaces;
using OngProject.UnitOfWork;
using System.Collections.Generic;

namespace OngProject.Services
{
    public class RolesService : BaseRepository<Roles, ONGDBContext>, IRolesService
    {
        private readonly UOW _unitOfWork;

        public RolesService(ONGDBContext dbContext) : base(dbContext)
        {

        }

        public RolesService(UOW unitOfWork, ONGDBContext dbContext) : base(dbContext)
        {
            _unitOfWork = unitOfWork;
        }

      
        public Roles AddRoles(Roles roles)
        {
            return Add(roles);
        }

        public Roles DeleteRoles(int id)
        {
            return Delete(id);
        }

        public Roles GetById(int id)
        {
            return Get(id); 
        }

        public List<Roles> GetRoles()
        {
            return GetAllEntities();
        }

        public Roles UpdateRoles(Roles roles)
        {
            return Update(roles);
        }
    }
}

using OngProject.Data;
using OngProject.Models;
using OngProject.Repositories;
using OngProject.Services.Interfaces;
using OngProject.UnitOfWork;
using System.Collections.Generic;

namespace OngProject.Services
{
    public class RolesService : IRolesService
    {
        private readonly UOW _unitOfWork;

        public RolesService(ONGDBContext dbContext) 
        {

        }

        public RolesService(UOW unitOfWork, ONGDBContext dbContext) 
        {
            _unitOfWork = unitOfWork;
        }

      
        public Roles AddRoles(Roles roles)
        {
            return _unitOfWork.RolesRepository.Add(roles);
        }

        public Roles DeleteRoles(int id)
        {
            return _unitOfWork.RolesRepository.Delete(id);
        }

        public Roles GetById(int id)
        {
            return _unitOfWork.RolesRepository.GetById(id);
        }

        public List<Roles> GetRoles()
        {
            return _unitOfWork.RolesRepository.GetAll();
        }

        public Roles UpdateRoles(Roles roles)
        {
            return _unitOfWork.RolesRepository.Update(roles);
        }
    }
}

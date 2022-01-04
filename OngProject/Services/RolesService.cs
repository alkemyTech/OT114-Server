using OngProject.Data;
using OngProject.Models;
using OngProject.Repositories;
using OngProject.Services.Interfaces;
using OngProject.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Services
{
    public class RolesService : IRolesService
    {
        private readonly UOW _unitOfWork;

        public RolesService()
        {

        }
        public RolesService(ONGDBContext dbContext) 
        {

        }

        public RolesService(UOW unitOfWork, ONGDBContext dbContext) 
        {
            _unitOfWork = unitOfWork;
        }

      
        public async Task<Roles> AddRoles(Roles roles)
        {
            return await _unitOfWork.RolesRepository.Add(roles);
        }

        public async Task<Roles> DeleteRoles(int id)
        {
            return await _unitOfWork.RolesRepository.Delete(id);
        }

        public async Task<Roles> GetById(int id)
        {
            return await _unitOfWork.RolesRepository.GetById(id);
        }

        public async Task<List<Roles>> GetRoles()
        {
            return await _unitOfWork.RolesRepository.GetAll();
        }

        public async Task<Roles> UpdateRoles(Roles roles)
        {
            return await _unitOfWork.RolesRepository.Update(roles);
        }
    }
}

using OngProject.Models;
using OngProject.Services.Interfaces;
using OngProject.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly UOW _unitOfWork;

        public OrganizationService(UOW unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Organization>> GetAll()
        {
            var org = _unitOfWork.OrganizationRepository.GetAll();
            return org.ToList();
        }
        public async Task<Organization> GetById(int id)
        {
            var org = _unitOfWork.OrganizationRepository.GetById(id);
            return org;
        }
        public async Task<Organization> Insert(Organization orga)
        {
            var org = _unitOfWork.OrganizationRepository.Add(orga);
            return org;
        }

        public virtual void Delete(int id)
        {
            _unitOfWork.OrganizationRepository.Delete(id);
        }

        public async Task<Organization> Update(Organization orga)
        {
            var org = _unitOfWork.OrganizationRepository.Update(orga);
            return org;
        }
    }
}

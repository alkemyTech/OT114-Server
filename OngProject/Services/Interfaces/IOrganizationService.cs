using OngProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Services.Interfaces
{
    public interface IOrganizationService
    {
        Task<List<Organization>> GetAll();
        Task<Organization> GetById(int id);
        Task<Organization> Insert(Organization organization);
        void Delete(int id);
        Task<Organization> Update(Organization organization);
    }
}

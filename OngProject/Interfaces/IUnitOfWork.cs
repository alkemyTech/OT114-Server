using OngProject.Repositories;
using System;

namespace OngProject.Unit_Of_Work
{
    public interface IUnitOfWork
    {
        OrganizacionRepository Organizacion { get; }

        void Save();
    }
}
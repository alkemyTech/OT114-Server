using OngProject.Context;
using OngProject.Entities;
using OngProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Unit_Of_Work
{
    public class UnitOfWork : IUnitOfWork
    {
        private OrganizacionRepository _organizacionRepository;
        private OngContext _ongContext1;
        public UnitOfWork(OngContext ongContext)
        {
            _ongContext1 = ongContext;
        }

        public OrganizacionRepository Organizacion
        {
            get
            {
                if (_organizacionRepository == null)
                {
                    _organizacionRepository = new OrganizacionRepository(_ongContext1);
                }
                return _organizacionRepository;
            }
        }

        public void Save()
        {
            _ongContext1.SaveChanges();
        }
    }
}

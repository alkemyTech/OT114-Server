using Microsoft.EntityFrameworkCore;
using OngProject.Data;
using OngProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Repositories
{
    public class OrganizationRepository : BaseRepository<Organization, ONGDBContext>
    {
        private readonly ONGDBContext _dbContext;

        public OrganizationRepository(ONGDBContext context) : base(context)
        {
            _dbContext = context;
        }


        public override Organization Delete(int id)
        {
            Organization OrgToDelete = _dbContext.Find<Organization>(id);

            if (OrgToDelete is not null)
            {
                OrgToDelete.deletedAt = DateTime.Now;
                _dbContext.Attach(OrgToDelete);
                _dbContext.Entry(OrgToDelete).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return OrgToDelete;
            }
            else
            {
                throw new Exception("La Organizacion no existe");
            }


        }
}
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
            Organization orgToDelete = _dbContext.Find<Organization>(id);
            if (orgToDelete.deletedAt == null)
            {
                orgToDelete.deletedAt = DateTime.Now;
            }
            _dbContext.Attach(orgToDelete);
            _dbContext.Entry(orgToDelete).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return orgToDelete;
        }
    }
}
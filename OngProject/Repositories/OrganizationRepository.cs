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

        public async override Task<Organization> GetById(int id)
        {
            return await DbSet.Include(x => x.Slide)
                .OrderBy(p=>p.Slide.Order)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async override Task<Organization> Delete(int id)
        {
            Organization OrgToDelete =await _dbContext.FindAsync<Organization>(id);

            if (OrgToDelete is not null)
            {
                OrgToDelete.deletedAt = DateTime.Now;
                _dbContext.Attach(OrgToDelete);
                _dbContext.Entry(OrgToDelete).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return OrgToDelete;
            }
            else
            {
                throw new Exception("La Organizacion no existe");
            }


        }
    }
}
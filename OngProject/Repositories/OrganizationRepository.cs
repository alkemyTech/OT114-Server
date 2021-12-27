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

        public override List<Organization> GetAll()
        {
            return DbSet.Where(o => o.deletedAt == null).ToList();
        }

        public override Organization GetById(int id)
        {
            var media = DbSet.Include(x => x.Miembros.FacebookUrl)
                               .Include(x => x.Miembros.InstagramUrl)
                               .Include(x => x.Miembros.LinkedinUrl).FirstOrDefault(x => x.Id == id);

            return media;
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
}
using Microsoft.EntityFrameworkCore;
using OngProject.Data;
using OngProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Repositories
{
    public class SlideRepository : BaseRepository<Slide, ONGDBContext>
    {
        private readonly ONGDBContext _context;
        public SlideRepository(ONGDBContext context) : base(context)
        {
            _context = context;
        }
        
         public override List<Slide> GetAll()
        {
            return DbSet.Where(m => m.DeletedAt == null).ToList();
        }
        
        public override Slide GetById(int id)
        {
            return DbSet.Include(x => x.Organization).FirstOrDefault(x => x.Id == id);
        }

    }
}

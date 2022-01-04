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
        
         public async override Task<List<Slide>> GetAll()
        {
            return await DbSet.Where(m => m.DeletedAt == null).ToListAsync();
        }
        
        public async override Task<Slide> GetById(int id)
        {
            return await DbSet.Include(x => x.Organization).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async override Task<Slide> Delete(int id)
        {
            var slide =await _context.FindAsync<Slide>(id);
            if (slide == null || slide.DeletedAt != null)
            {
                 throw new Exception("El Slide no existe.");
            }
            else
            {
                slide.DeletedAt = DateTime.Now;
                _context.Attach(slide);
                _context.Entry(slide).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return slide;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using OngProject.Data;
using OngProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Repositories
{
    public class TestimonialRepository : BaseRepository<Testimonials, ONGDBContext>
    {
        private readonly ONGDBContext _dbContext;

        public TestimonialRepository(ONGDBContext context) : base(context)
        {
            _dbContext = context;
        }


        public async override Task<List<Testimonials>> GetAll()
        {
            var TestimonialActive =await _dbContext.Testimonials.Where(c => c.DeletedAt == null).ToListAsync();
            return (TestimonialActive);
        }
        public async override Task<Testimonials> Delete(int id)
        {
            Testimonials TestiToDelete = await _dbContext.FindAsync<Testimonials>(id);
            if ((TestiToDelete == null) || (TestiToDelete.DeletedAt != null))
            {
                throw new Exception("el comentario no existe");
            }
            else
            {
                TestiToDelete.DeletedAt = DateTime.Now;
                _dbContext.Attach(TestiToDelete);
                _dbContext.Entry(TestiToDelete).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return TestiToDelete;
            }
        }
    }
   
}
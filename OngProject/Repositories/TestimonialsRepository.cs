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


        public override List<Testimonials> GetAll()
        {
            var TestimonialActive = _dbContext.Testimonials.Where(c => c.DeletedAt == null);
            return (List<Testimonials>)TestimonialActive;
        }
        public override Testimonials Delete(int id)
        {
            Testimonials TestiToDelete = _dbContext.Find<Testimonials>(id);
            if ((TestiToDelete == null) || (TestiToDelete.DeletedAt != null))
            {
                throw new Exception("el comentario no existe");
            }
            else
            {
                TestiToDelete.DeletedAt = DateTime.Now;
                _dbContext.Attach(TestiToDelete);
                _dbContext.Entry(TestiToDelete).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return TestiToDelete;
            }
        }
    }
   
}
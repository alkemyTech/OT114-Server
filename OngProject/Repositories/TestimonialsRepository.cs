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


        public override Testimonials Delete(int id)
        {
            Testimonials TestiToDelete = _dbContext.Find<Testimonials>(id);
            if (TestiToDelete.DeletedAt == null)
            {
                TestiToDelete.DeletedAt = DateTime.Now;
            }
            _dbContext.Attach(TestiToDelete);
            _dbContext.Entry(TestiToDelete).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return TestiToDelete;
        }
    }
}
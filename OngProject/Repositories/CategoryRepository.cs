using Microsoft.EntityFrameworkCore;
using OngProject.Data;
using OngProject.Interfaces;
using OngProject.Models;
using OngProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Repositories
{
    public class CategoryRepository : BaseRepository<Category, ONGDBContext>
    {
        private readonly ONGDBContext _dbContext;

        public CategoryRepository(ONGDBContext context) : base(context)
        {
            _dbContext = context;
        }


        public override Category Delete(int id)
        {
            Category catTodelete = _dbContext.Find<Category>(id);
            if (catTodelete.deletedAt == null)
            {
                catTodelete.deletedAt = DateTime.Now;
            }
            _dbContext.Attach(catTodelete);
            _dbContext.Entry(catTodelete).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return catTodelete;
        }
    }
}
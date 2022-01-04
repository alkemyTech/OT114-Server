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

        public async override Task<List<Category>> GetAll()
        {
            return await _dbContext.Categories.Where(cate => cate.deletedAt == null).ToListAsync();
        }

        public async override Task<Category> Delete(int id)
        {
            Category category =await _dbContext.FindAsync<Category>(id);

            if ((category == null) || (category.deletedAt != null))
            {
                throw new Exception("la categoria no existe");
            }
            else
            {
                category.deletedAt = DateTime.Now;
                _dbContext.Attach(category);
                _dbContext.Entry(category).State = EntityState.Modified;
               await _dbContext.SaveChangesAsync();
                return category;
            }
        }
    }
}
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

        public override List<Category> GetAll()
        {
            return _dbContext.Categories.Where(cate => cate.deletedAt == null).ToList();
        }

        public override Category Delete(int id)
        {
            Category category = _dbContext.Find<Category>(id);

            if ((category == null) || (category.deletedAt != null))
            {
                throw new Exception("la categoria no existe");
            }
            else
            {
                category.deletedAt = DateTime.Now;
                _dbContext.Attach(category);
                _dbContext.Entry(category).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return category;
            }
        }
    }
}
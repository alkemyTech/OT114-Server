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
    public class CategoryRepository : BaseRepository<Category, ONGDBContext>, ICategoryService
    {
        public CategoryRepository(ONGDBContext context ):base(context)
        {
        }



        public Category AddCategory(Category category)
        {
            return Add(category);
        }

        public List<Category> GetAllCategory()
    {
            return GetAllEntities();
        }

        public Category GetCategory(Category category)
        {
            return Get(category.Id);
        }
            
        public Category UpdateCategory(Category category)
        {
            return Update(category);
        }
       
    }
}

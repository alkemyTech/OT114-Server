using OngProject.Data;
using OngProject.Models;
using OngProject.Services.Interfaces;
using System.Collections.Generic;

namespace OngProject.Repositories
{
    public class CategoryRepository : BaseRepository<Category, ONGDBContext>, ICategoryService
    {
        

        public CategoryRepository(ONGDBContext dbContext) : base(dbContext)
        {
        }

        public Category AddCategory(Category category)
        {
            throw new System.NotImplementedException();
        }

        public List<Category> GetAllCategory()
        {
            throw new System.NotImplementedException();
        }

        public Category GetCategory(Category category)
        {
            throw new System.NotImplementedException();
        }

        public Category UpdateCategory(Category category)
        {
            throw new System.NotImplementedException();
        }
    }
}

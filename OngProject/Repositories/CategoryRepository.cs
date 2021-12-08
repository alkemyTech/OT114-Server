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
    public class CategoryRepository : BaseRepository<Category, ONGDBContext> ,ICategoryService
    {
        public CategoryRepository(ONGDBContext context) : base(context)
        {
        }

        public Task<Category> Insert(Category category)
        {
            throw new NotImplementedException();
        }

        void ICategoryService.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Task<List<Category>> ICategoryService.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<Category> ICategoryService.GetById(int id)
        {
            throw new NotImplementedException();
        }

        Task<Category> ICategoryService.Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}

using OngProject.Interfaces;
using OngProject.Models;
using OngProject.Repositories;
using OngProject.Data;
using OngProject.Services.Interfaces;
using OngProject.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Services
{
    public class CategoryService : BaseRepository<Category, ONGDBContext>, ICategoryService
    {
        private readonly UOW _unitOfWork;

       

        public CategoryService(ONGDBContext dbContext) : base(dbContext)
        {

        }

        public CategoryService(UOW unitOfWork, ONGDBContext dbContext) : base(dbContext)
        {
            _unitOfWork = unitOfWork;
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

using OngProject.Interfaces;
using OngProject.Models;
using OngProject.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly UOW _unitOfWork;

        public CategoryService(UOW unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Category> GetAll()
        {
            var category =  _unitOfWork.CategoryRepository.GetAllEntities();
            return category.ToList();
        }
    }
}

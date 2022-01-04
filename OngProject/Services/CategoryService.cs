using OngProject.Interfaces;
using OngProject.Models;
using OngProject.Repositories;
using OngProject.Data;
using System.Collections.Generic;
using OngProject.UnitOfWork;
using System.Threading.Tasks;
using System.Linq;

namespace OngProject.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly UOW _unitOfWork;
        public CategoryService()
        {

        }
        public CategoryService(UOW unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Category>> GetAll()
        {
            var category =await _unitOfWork.CategoryRepository.GetAll();
            return category.ToList();
        }
        public async Task<Category> GetById(int id)
        {
            var category =await _unitOfWork.CategoryRepository.GetById(id);
            return category;
        }
        public async Task<Category> Insert(Category cat)
        {
            var category =await _unitOfWork.CategoryRepository.Add(cat);
            return category;
        }
        public async Task<Category> Delete(int id)
        {
            var category =await _unitOfWork.CategoryRepository.Delete(id);
            return category;
        }
        public async Task<Category> Update(Category cat)
        {
            var category =await _unitOfWork.CategoryRepository.Update(cat);
            return category;
        }
    }
}

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
        public CategoryService(UOW unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Category>> GetAll()
        {
            var cate = _unitOfWork.CategoryRepository.GetAll();
            return cate.ToList();
        }
        public async Task<Category> GetById(int id)
        {
            var cate = _unitOfWork.CategoryRepository.GetById(id);
            return cate;
        }
        public async Task<Category> Insert(Category cat)
        {
            var cate = _unitOfWork.CategoryRepository.Add(cat);
            return cate;
        }

        public virtual void Delete(int id)
        {
            _unitOfWork.CategoryRepository.Delete(id);
        }

        public async Task<Category> Update(Category cat)
        {
            var cate = _unitOfWork.CategoryRepository.Update(cat);
            return cate;
        }
    }
}

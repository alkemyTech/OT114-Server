using OngProject.Models;
using OngProject.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace OngProject.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAll();
        Task<Category> GetById(int id);
        Task<Category> Insert(Category category);
        Task<Category> Delete(int id);
        Task<Category> Update(Category category);
    }
}

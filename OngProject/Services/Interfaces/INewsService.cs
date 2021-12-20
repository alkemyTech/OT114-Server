using OngProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Services
{
    public interface INewsService
    {
        Task<News> Delete(int id);
        Task<List<News>> GetAll();
        Task<News> GetById(int id);
        Task<News> Insert(News news);
        Task<News> Update(News news);
    }
}
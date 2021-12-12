using OngProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Services
{
    public interface INewsService
    {
        void Delete(int id);
        Task<List<News>> GetAll();
        Task<News> GetId(int id);
        Task<News> Insert(News news);
        Task<News> Update(News news);
    }
}
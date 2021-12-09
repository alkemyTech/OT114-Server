using OngProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Services
{
    public interface INewsService
    {
        void DeleteNews(int id);
        Task<List<News>> GetAllNews();
        Task<News> GetIdNews(int id);
        Task<News> InsertNews(News news);
        Task<News> UpdateNews(News news);
    }
}
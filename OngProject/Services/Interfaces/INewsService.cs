using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Services.Interfaces
{
    public interface INewsService
    {
        Task<List<News>> GetAll();
        Task<News> GetById(int id);
        Task<News> Insert(News news);
        void Delete(int id);
        Task<News> Update(News news);
    }
}

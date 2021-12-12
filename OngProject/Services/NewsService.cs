using OngProject.Models;
using OngProject.Services.Interfaces;
using OngProject.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Services
{
    public class NewsService : INewsService
    {
        private readonly UOW _unitOfWork;

        public NewsService(UOW unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<News>> GetAll()
        {
            var newsList = _unitOfWork.NewsRepository.GetAll();
            return newsList.ToList();
        }

        public async Task<News> GetById(int id)
        {
            var news = _unitOfWork.NewsRepository.GetById(id);
            return news;
        }

        public async Task<News> Insert(News news)
        {
            var CreateNews = _unitOfWork.NewsRepository.Add(news);
            return CreateNews;
        }

        public void DeleteNews(int id)
        {
            _unitOfWork.NewsRepository.Delete(id);
        }

        public async Task<News> UpdateNews(News news)
        {
            var EditNews = _unitOfWork.NewsRepository.Update(news);
            return EditNews;
        }








    }
}

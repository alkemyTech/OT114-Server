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

        public NewsService()
        {

        }
        public NewsService(UOW unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<News>> GetAll()
        {
            var newsList = await _unitOfWork.NewsRepository.GetAll();
            return newsList.ToList();
        }

        public async Task<News> GetById(int id)
        {
            var news =await _unitOfWork.NewsRepository.GetById(id);
            return news;
        }

        public async Task<News> Insert(News news)
        {
            var CreateNews =await _unitOfWork.NewsRepository.Add(news);
            return CreateNews;
        }

        public async Task<News> Delete(int id)
        {
            var news =await _unitOfWork.NewsRepository.Delete(id);
            return news;
        }

        public async Task<News> Update(News news)
        {
            var EditNews =await _unitOfWork.NewsRepository.Update(news);
            return EditNews;
        }
    }
}
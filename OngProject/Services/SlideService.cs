using OngProject.Models;
using OngProject.Services.Interfaces;
using OngProject.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Services
{
    public class SlideService : ISlideService
    {
        private readonly UOW _unitOfWork;

        public SlideService()
        {

        }
        public SlideService(UOW unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Slide>> GetAll()
        {
            var slide = await _unitOfWork.SlideRepository.GetAll();
            return slide.ToList();
        }
        public async Task<Slide> GetById(int id)
        {
            var slide =await _unitOfWork.SlideRepository.GetById(id);
            return slide;
        }
        public async Task<Slide> Insert(Slide s)
        {
            var slide =await _unitOfWork.SlideRepository.Add(s);
            return slide;
        }
        public async Task<Slide> Delete(int id)
        {
            var slide =await _unitOfWork.SlideRepository.Delete(id);
            return slide;
        }
        public async Task<Slide> Update(Slide s)
        {
            var slide =await _unitOfWork.SlideRepository.Update(s);
            return slide;
        }
    }
}

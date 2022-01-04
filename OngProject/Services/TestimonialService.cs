using OngProject.Models;
using OngProject.Services.Interfaces;
using OngProject.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Services
{
    public class TestimonialService : ITestimonialService
    {
        private readonly UOW _unitOfWork;

        public TestimonialService()
        {

        }
        public TestimonialService(UOW unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Testimonials>> GetAll()
        {
            var testimonials = await _unitOfWork.TestimonialRepository.GetAll();
            return testimonials.ToList();
        }
        public async Task<Testimonials> GetById(int id)
        {
            var testimonial =await _unitOfWork.TestimonialRepository.GetById(id);
            return testimonial;
        }
        public async Task<Testimonials> Insert(Testimonials test)
        {
            var testimonial =await _unitOfWork.TestimonialRepository.Add(test);
            return testimonial;
        }

        public async virtual void Delete(int id)
        {
          await  _unitOfWork.TestimonialRepository.Delete(id);
        }

        public async Task<Testimonials> Update(Testimonials test)
        {
            var testomonial =await _unitOfWork.TestimonialRepository.Update(test);
            return testomonial;
        }
    }
}

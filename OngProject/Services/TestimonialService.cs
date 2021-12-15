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
        public TestimonialService(UOW unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Testimonials>> GetAll()
        {
            var testimonials = _unitOfWork.TestimonialRepository.GetAll();
            return testimonials.ToList();
        }
        public async Task<Testimonials> GetById(int id)
        {
            var testimonial = _unitOfWork.TestimonialRepository.GetById(id);
            return testimonial;
        }
        public async Task<Testimonials> Insert(Testimonials test)
        {
            var testimonial = _unitOfWork.TestimonialRepository.Add(test);
            return testimonial;
        }

        public virtual void Delete(int id)
        {
            _unitOfWork.TestimonialRepository.Delete(id);
        }

        public async Task<Testimonials> Update(Testimonials test)
        {
            var testomonial = _unitOfWork.TestimonialRepository.Update(test);
            return testomonial;
        }
    }
}

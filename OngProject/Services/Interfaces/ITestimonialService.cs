using OngProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Services.Interfaces
{
    public interface ITestimonialService
    {
        Task<List<Testimonials>> GetAll();
        Task<Testimonials> GetById(int id);
        Task<Testimonials> Insert(Testimonials testimonial);
        void Delete(int id);
        Task<Testimonials> Update(Testimonials testimonial);
    }
}

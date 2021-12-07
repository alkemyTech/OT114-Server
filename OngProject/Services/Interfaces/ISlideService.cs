using OngProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Services.Interfaces
{
    public interface ISlideService
    {
        Task<List<Slide>> GetAll();
        Task<Slide> GetById(int id);
        Task<Slide> Insert(Slide slide);
        void Delete(int id);
        Task<Slide> Update(Slide slide);
    }
}

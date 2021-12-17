using OngProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Services.Interfaces
{
    public interface ICommentsService
    {
        Task<List<Comments>> GetAll();
        Task<Comments> GetById(int id);
        Task<Comments> Insert(Comments comments);
        Task<Comments> Delete(int id);
        Task<Comments> Update(Comments comments);
    }
}

using OngProject.Models;
using OngProject.Services.Interfaces;
using OngProject.UnitOfWork;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Services
{
    public class CommentsService : ICommentsService
    {
        private readonly UOW _unitOfWork;

        public CommentsService(UOW unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<Comments> Delete(int id)
        {
            var comment = _unitOfWork.CommentsRepository.Delete(id);
            return comment();
        }

        public Task<List<Comments>> GetAll()
        {
            var comment = _unitOfWork.CommentsRepository.GetAll();
            return comment.ToList();
        }

        public Task<Comments> GetById(int id)
        {
            var comment = _unitOfWork.CommentsRepository.GetById(id);
            return comment;
        }

        public Task<Comments> Insert(Comments comments)
        {
            var comment = _unitOfWork.CommentsRepository.Add(comments);
            return comment;
        }

        public Task<Comments> Update(Comments comments)
        {
            var comment = _unitOfWork.CommentsRepository.Update(comments);
            return comment;
        }
    }
}

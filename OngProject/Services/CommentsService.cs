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

        public CommentsService()
        {

        }
        public CommentsService(UOW unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Comments> Delete(int id)
        {
            var comment =await _unitOfWork.CommentsRepository.Delete(id);
            return comment;
        }

        public async Task<List<Comments>> GetAll()
        {
            var comment =await _unitOfWork.CommentsRepository.GetAll();
            return comment.ToList();
        }

        public async Task<Comments> GetById(int id)
        {
            var comment =await _unitOfWork.CommentsRepository.GetById(id);
            return comment;
        }

        public async Task<Comments> Insert(Comments comments)
        {
            var comment =await _unitOfWork.CommentsRepository.Add(comments);
            return comment;
        }

        public async Task<Comments> Update(Comments comments)
        {
            var comment =await _unitOfWork.CommentsRepository.Update(comments);
            return comment;
        }
    }
}

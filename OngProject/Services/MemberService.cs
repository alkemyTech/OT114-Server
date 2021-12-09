using OngProject.Models;
using OngProject.Services.Interfaces;
using OngProject.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Services
{
    public class MemberService : IMemberService
    {
        private readonly UOW _unitOfWork;
        public MemberService(UOW unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Member>> GetAll()
        {
            var member = _unitOfWork.MemberRepository.GetAll();
            return member.ToList();
        }
        public async Task<Member> GetById(int id)
        {
            var member = _unitOfWork.MemberRepository.GetById(id);
            return member;
        }
        public async Task<Member> Insert(Member mem)
        {
            var member = _unitOfWork.MemberRepository.Add(mem);
            return member;
        }
        public async Task<Member> Delete(int id)
        {
            var member = _unitOfWork.MemberRepository.Delete(id);
            return member;
        }
        public async Task<Member> Update(Member mem)
        {
            var member = _unitOfWork.MemberRepository.Update(mem);
            return member;
        }
    }
}

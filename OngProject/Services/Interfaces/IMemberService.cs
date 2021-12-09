using OngProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Services.Interfaces
{
    public interface IMemberService
    {
        Task<List<Member>> GetAll();
        Task<Member> GetById(int id);
        Task<Member> Insert(Member member);
        Task<Member> Delete(int id);
        Task<Member> Update(Member member);
    }
}

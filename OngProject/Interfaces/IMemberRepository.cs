using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Interfaces
{
    public interface IMemberRepository : IBaseRepository<Member>
    {
        Member GetMember(int id);
        List<Member> GetMembers();
    }
}

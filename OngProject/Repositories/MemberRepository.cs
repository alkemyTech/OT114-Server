using OngProject.Context;
using OngProject.Entities;
using OngProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Repositories
{
    public class MemberRepository : BaseRepository<Member, OngContext>, IMemberRepository
    {
        public Member GetMember(int id)
        {
            throw new NotImplementedException();
        }

        public List<Member> GetMembers()
        {
            throw new NotImplementedException();
        }
    }
}

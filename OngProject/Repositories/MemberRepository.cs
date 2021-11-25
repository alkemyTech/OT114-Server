using OngProject.Entities;
using OngProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Repositories
{
    public class MemberRepository : BaseRepository<Member, Context>, IMemberRepository
    {
     

        public Member GetMember(int id)
        {
           
        }

        public List<Member> GetMembers()
        {
           
        }

    }
}

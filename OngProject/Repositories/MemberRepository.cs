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
        public MemberRepository(OngContext dbContext) : base(dbContext)
        {
        }

        public Member GetMember(int id)
        {
            return DbSet.FirstOrDefault(x => x.Id == id);
        }

        public List<Member> GetMembers()
        {
            return DbSet.ToList();
        }
    }
}

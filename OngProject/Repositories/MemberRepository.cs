using OngProject.Data;
using OngProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Repositories
{
    public class MemberRepository : BaseRepository<Member, ONGDBContext>
    {
        public MemberRepository(ONGDBContext context) : base(context)
        {
        }
    }
}

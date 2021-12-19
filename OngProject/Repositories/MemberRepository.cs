using Microsoft.EntityFrameworkCore;
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
        private readonly ONGDBContext _context;
        public MemberRepository(ONGDBContext context) : base(context)
        {
            _context = context;
        }
        public override List<Member> GetAll()
        {
            return DbSet.Where(m => m.DeletedAt == null).ToList();
        }
        public override Member Delete(int id)
        {
            Member member = _context.Find<Member>(id);

            if ((member == null) || (member.DeletedAt != null))
            {
                throw new Exception("el miembro no existe");
            }
            else
            {
                member.DeletedAt = DateTime.Now;
                _context.Attach(member);
                _context.Entry(member).State = EntityState.Modified;
                _context.SaveChanges();
                return member;
            }
        }
    }
}

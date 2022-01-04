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
        public async override Task<List<Member>> GetAll()
        {
            return await DbSet.Where(m => m.DeletedAt == null).ToListAsync();
        }
        public async override Task<Member> Delete(int id)
        {
            Member member =await _context.FindAsync<Member>(id);

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

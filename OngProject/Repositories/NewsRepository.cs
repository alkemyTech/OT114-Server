using Microsoft.EntityFrameworkCore;
using OngProject.Data;
using OngProject.Models;
using OngProject.Services;
using OngProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Repositories
{
    public class NewsRepository : BaseRepository<News,ONGDBContext>
    {
        private readonly ONGDBContext _context;
        public NewsRepository(ONGDBContext context)
            :base(context)
        {
            _context = context;
        }

        public async override Task<List<News>> GetAll()
        {
            return await DbSet.Where(x => x.DeletedAt == null).ToListAsync();
        }

        public async override Task<News> Delete(int id)
        {
            News news =await _context.FindAsync<News>(id);
            if (news == null || news.DeletedAt != null)
            {
                throw new Exception("La novedad no existe.");
            }
            news.DeletedAt = DateTime.Now;
            _context.Attach(news);
            _context.Entry(news).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return news;
        }
    }
}

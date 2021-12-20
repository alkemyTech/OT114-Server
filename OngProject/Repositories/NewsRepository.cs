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

        public override List<News> GetAll()
        {
            return DbSet.Where(x => x.DeletedAt == null).ToList();
        }

        public override News Delete(int id)
        {
            News news = _context.Find<News>(id);
            if (news == null || news.DeletedAt == null)
            {
                throw new Exception("La novedad no existe.");
            }
            news.DeletedAt = DateTime.Now;
            _context.Attach(news);
            _context.Entry(news).State = EntityState.Modified;
            _context.SaveChanges();
            return news;
        }
    }
}

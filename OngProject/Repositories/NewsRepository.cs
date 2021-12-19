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
        private readonly ONGDBContext _oNGDBContext;
        public NewsRepository(ONGDBContext context)
            :base(context)
        {
            _oNGDBContext = context;
        }
        public override News Delete(int id)
        {
            News news = _oNGDBContext.Find<News>(id);
            if (news == null || news.DeletedAt != null)
            {
                throw new Exception("La novedad no existe.");
            }
            news.DeletedAt = DateTime.Now;
            _oNGDBContext.Attach(news);
            _oNGDBContext.Entry(news).State = EntityState.Modified;
            _oNGDBContext.SaveChanges();
            return news;
        }
    }
}

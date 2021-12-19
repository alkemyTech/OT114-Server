using Microsoft.EntityFrameworkCore;
using OngProject.Data;
using OngProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Repositories
{
    public class ActivityRepository : BaseRepository<Activity, ONGDBContext>
    {
        private readonly ONGDBContext _dbContext;

        public ActivityRepository(ONGDBContext context) : base(context)
        {
            _dbContext = context;
        }
        public override Activity Delete(int id)
        {
            Activity ActiTodelete = _dbContext.Find<Activity>(id);
            if (ActiTodelete.deletedAt == null)
            {
                ActiTodelete.deletedAt = DateTime.Now;
            }
            _dbContext.Attach(ActiTodelete);
            _dbContext.Entry(ActiTodelete).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return ActiTodelete;
        }
    }
}
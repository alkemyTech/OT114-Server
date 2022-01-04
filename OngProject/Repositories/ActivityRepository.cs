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
        public async override Task<Activity> Delete(int id)
        {
            Activity ActiTodelete =await _dbContext.FindAsync<Activity>(id);
            if (ActiTodelete.deletedAt == null)
            {
                ActiTodelete.deletedAt = DateTime.Now;
            }
            _dbContext.Attach(ActiTodelete);
            _dbContext.Entry(ActiTodelete).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return ActiTodelete;
        }
    }
}
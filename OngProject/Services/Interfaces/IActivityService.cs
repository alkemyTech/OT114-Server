using OngProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Services.Interfaces
{
    public interface IActivityService
    {
        Task<List<Activity>> GetAll();
        Task<Activity> GetById(int id);
        Task<Activity> Insert(Activity activity);
        void Delete(int id);
        Task<Activity> Update(Activity activity);
    }
}

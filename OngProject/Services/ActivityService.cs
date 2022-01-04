using OngProject.Models;
using OngProject.Services.Interfaces;
using OngProject.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Services
{
    public class ActivityService : IActivityService
    {
        private readonly UOW _unitOfWork;
        public ActivityService()
        {

        }
        public ActivityService(UOW unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Activity>> GetAll()
        {
            var activity = await _unitOfWork.ActivityRepository.GetAll();
            return activity.ToList();
        }
        public async Task<Activity> GetById(int id)
        {
            var activity =await _unitOfWork.ActivityRepository.GetById(id);
            return activity;
        }
        public async Task<Activity> Insert(Activity cat)
        {
            var activity =await _unitOfWork.ActivityRepository.Add(cat);
            return activity;
        }

        public async  virtual void Delete(int id)
        {
          await  _unitOfWork.ActivityRepository.Delete(id);
        }

        public async Task<Activity> Update(Activity cat)
        {
            var activity =await _unitOfWork.ActivityRepository.Update(cat);
            return activity;
        }
    }
}

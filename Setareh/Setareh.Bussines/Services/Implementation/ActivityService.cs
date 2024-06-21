using Microsoft.EntityFrameworkCore.ChangeTracking;
using Setareh.Bussines.Services.Interface;
using Setareh.DAL.Repositories.Interface;
using Setareh.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setareh.Bussines.Services.Implementation
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;
        public ActivityService(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public Task<FilterActivityViewModel> FilterAsync(FilterActivityViewModel model)
        {
            return _activityRepository.FilterAsync(model);
        }
    }
}

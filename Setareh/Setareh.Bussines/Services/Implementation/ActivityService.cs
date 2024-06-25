using Setareh.Bussines.Services.Interface;
using Setareh.DAL.Entities.Acitivity;
using Setareh.DAL.Repositories.Interface;
using Setareh.DAL.ViewModels;

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

        public async Task<EditActivityViewModel?> GetInfoByIdAsync(int id)
        {
            return await _activityRepository.GetInfoAsync(id);
        }

        public async Task<EditActivityResult> UpdateAsync(EditActivityViewModel model)
        {
            var activity = await _activityRepository.GetByIdAsync(model.Id);

            if(activity == null)
                return EditActivityResult.NotFound;

            activity.Title = model.Title;
            activity.Description = model.Description;
            activity.Icon = model.Icon;

            _activityRepository.Update(activity);
            await _activityRepository.SaveAsync();

            return EditActivityResult.Success;
        }
        public async Task<CreateActivityResult> CreateAsync(CreateActivityViewModel model)
        {
            var activity = new Activity
            {
                CreateDate = DateTime.Now,
                Description = model.Description,
                Icon = model.Icon,
                Title = model.Title
            };

            await _activityRepository.InsertAsync(activity);
            await _activityRepository.SaveAsync();

            return CreateActivityResult.Success;
        }

		public async Task<List<ActivityDetailViewModel>> GetAllActivitesAsync()
		{
			return await _activityRepository.GetAllActivites();                
		}
	}
}

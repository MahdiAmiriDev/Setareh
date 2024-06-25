using Setareh.DAL.Entities.Acitivity;
using Setareh.DAL.ViewModels.Activity;

namespace Setareh.DAL.Repositories.Interface
{
    public interface IActivityRepository
    {
        Task<FilterActivityViewModel> FilterAsync(FilterActivityViewModel model);

        Task InsertAsync(Activity activity);

        void Update(Activity activity);

        Task SaveAsync();

        Task<EditActivityViewModel?> GetInfoAsync(int id);

        Task<Activity?> GetByIdAsync(int id);

        Task<List<ActivityDetailViewModel>> GetAllActivites();

	}
}

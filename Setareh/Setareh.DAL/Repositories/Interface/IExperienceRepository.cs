using Setareh.DAL.Entities.Education;
using Setareh.DAL.Entities.Expreince;
using Setareh.DAL.ViewModels.Experience;

namespace Setareh.DAL.Repositories.Interface
{
    public interface IExperienceRepository
    {
        Task<FilterExperienceViewModel> FilterAsync(FilterExperienceViewModel model);

        Task InsertAsync(Experience model);

        Task SaveChangeAsync();

        Task<EditExperienceViewModel?> EditAsync(EditExperienceViewModel model);

        Task<Experience?> GetByIdAsync(int id);

        void Update(Experience education);

        Task<EditExperienceViewModel> GetForEditbyIdAsync(int id);

    }
}

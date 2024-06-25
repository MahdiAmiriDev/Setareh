using Setareh.DAL.ViewModels.Activity;
using Setareh.DAL.ViewModels.Experience;


namespace Setareh.Bussines.Services.Interface
{
    public interface IExperienceService
    {
        Task<FilterExperienceViewModel> FilterAsync(FilterExperienceViewModel model);

        Task<CreateActivityResult> Create(CreateExperienceViewModel model);

        Task<EditExperienceResult> EditAsync(EditExperienceViewModel model);

        Task<EditExperienceViewModel> GetForEditbyIdAsync(int id);
    }
}

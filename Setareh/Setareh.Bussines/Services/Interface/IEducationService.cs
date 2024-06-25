using Setareh.DAL.ViewModels;


namespace Setareh.Bussines.Services.Interface
{
    public interface IEducationService
    {
        Task<FilterEducationViewModel> FilterAsync(FilterEducationViewModel model);

        Task<CreateActivityResult> Create(CreateEducationViewModel model);

        Task<EditEducationResult> EditAsync(EditEducationViewModel model);

        Task<EditEducationViewModel> GetForEditbyIdAsync(int id);
    }
}

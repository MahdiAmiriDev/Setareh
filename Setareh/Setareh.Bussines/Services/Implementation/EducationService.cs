using Setareh.Bussines.Services.Interface;
using Setareh.DAL.Entities.Education;
using Setareh.DAL.Repositories.Interface;
using Setareh.DAL.ViewModels;

namespace Setareh.Bussines.Services.Implementation
{
    public class EducationService : IEducationService
    {
        private readonly IEducationRepository _repository;
        public EducationService(IEducationRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateActivityResult> Create(CreateEducationViewModel model)
        {
            Education education = new()
            {
                CreateDate = DateTime.Now,
                Description = model.Description,
                End = model.End,
                Start = model.Start,
                Title = model.Title
            };

            await _repository.InsertAsync(education);
            await _repository.SaveChangeAsync();

            return CreateActivityResult.Success;
        }

        public async Task<EditEducationResult> EditAsync(EditEducationViewModel model)
        {
            var education = await _repository.GetByIdAsync(model.Id);

            if(education == null)
                return EditEducationResult.NotFound;

            education.Description = model.Description;
            education.End = model.End;
            education.Start = model.Start;
            education.Title = model.Title;

            _repository.Update(education);
            await _repository.SaveChangeAsync();
            return EditEducationResult.Success;
        }

        public async Task<FilterEducationViewModel> FilterAsync(FilterEducationViewModel model)
        {
            return await _repository.FilterAsync(model);
        }

        public async Task<EditEducationViewModel> GetForEditbyIdAsync(int id)
        {
            return await _repository.GetForEditbyIdAsync(id);
        }
    }
}

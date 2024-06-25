using Setareh.Bussines.Services.Interface;
using Setareh.DAL.Entities.Expreince;
using Setareh.DAL.Repositories.Interface;
using Setareh.DAL.ViewModels;

namespace Setareh.Bussines.Services.Implementation
{
    public class ExperienceService : IExperienceService
    {
        private readonly IExperienceRepository _repository;
        public ExperienceService(IExperienceRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateActivityResult> Create(CreateExperienceViewModel model)
        {
            Experience experience = new()
            {
                CreateDate = DateTime.Now,
                Description = model.Description,
                End = model.End,
                Start = model.Start,
                Title = model.Title
            };

            await _repository.InsertAsync(experience);
            await _repository.SaveChangeAsync();

            return CreateActivityResult.Success;
        }

        public async Task<EditExperienceResult> EditAsync(EditExperienceViewModel model)
        {
            var experience = await _repository.GetByIdAsync(model.Id);

            if(experience == null)
                return EditExperienceResult.NotFound;

            experience.Description = model.Description;
            experience.End = model.End;
            experience.Start = model.Start;
            experience.Title = model.Title;

            _repository.Update(experience);
            await _repository.SaveChangeAsync();
            return EditExperienceResult.Success;
        }

        public async Task<FilterExperienceViewModel> FilterAsync(FilterExperienceViewModel model)
        {
            return await _repository.FilterAsync(model);
        }

        public async Task<EditExperienceViewModel> GetForEditbyIdAsync(int id)
        {
            return await _repository.GetForEditbyIdAsync(id);
        }
    }
}

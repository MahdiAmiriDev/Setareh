using Setareh.Bussines.Services.Interface;
using Setareh.DAL.Entities.Acitivity;
using Setareh.DAL.Entities.skill;
using Setareh.DAL.Repositories.Interface;
using Setareh.DAL.ViewModels.Activity;
using Setareh.DAL.ViewModels.Skill;

namespace Setareh.Bussines.Services.Implementation
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;
        public SkillService(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }
        public async Task<FilterSkillViewModel> FilterAsync(FilterSkillViewModel model)
        {
            return await _skillRepository.FilterAsync(model);
        }

        public async Task<EditSkillViewModel?> GetInfoByIdAsync(int id)
        {
            return await _skillRepository.GetInfoAsync(id);
        }

        public async Task<EditSkillResult> UpdateAsync(EditSkillViewModel model)
        {
            var skill = await _skillRepository.GetByIdAsync(model.Id);

            if(skill == null)
                return EditSkillResult.NotFound;

            skill.Title = model.Title;
            skill.Percentage = model.Percentage;            

            _skillRepository.Update(skill);
            await _skillRepository.SaveAsync();

            return EditSkillResult.Success;
        }
        public async Task<CreateSkillResult> CreateAsync(CreateSkillViewModel model)
        {
            var skill = new Skill
            {
                CreateDate = DateTime.Now,
                Percentage = model.Percentage,
                Title = model.Title
            };

            await _skillRepository.InsertAsync(skill);
            await _skillRepository.SaveAsync();

            return CreateSkillResult.Success;
        }

		public async Task<List<SkillDetailViewModel>> GetAllSkillsAsync()
		{
			return await _skillRepository.GetAllSkills();                
		}
	}
}

using Setareh.DAL.Entities.skill;
using Setareh.DAL.ViewModels.Activity;
using Setareh.DAL.ViewModels.Skill;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Setareh.DAL.Repositories.Interface
{
    public interface ISkillRepository
    {
        Task<FilterSkillViewModel> FilterAsync(FilterSkillViewModel model);

        Task InsertAsync(Skill skill);

        void Update(Skill skill);

        Task SaveAsync();

        Task<EditSkillViewModel?> GetInfoAsync(int id);

        Task<Skill?> GetByIdAsync(int id);

        Task<List<SkillDetailViewModel>> GetAllSkills();
    }
}

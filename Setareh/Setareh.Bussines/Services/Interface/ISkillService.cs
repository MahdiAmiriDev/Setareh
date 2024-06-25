using Setareh.DAL.Entities.skill;
using Setareh.DAL.ViewModels.Activity;
using Setareh.DAL.ViewModels.Skill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setareh.Bussines.Services.Interface
{
    public interface ISkillService
    {
        Task<FilterSkillViewModel> FilterAsync(FilterSkillViewModel model);

        Task<CreateSkillResult> CreateAsync(CreateSkillViewModel model);
        Task<EditSkillResult> UpdateAsync(EditSkillViewModel model);
        Task<EditSkillViewModel?> GetInfoByIdAsync(int id);

        Task<List<SkillDetailViewModel>> GetAllSkillsAsync();
    }
}

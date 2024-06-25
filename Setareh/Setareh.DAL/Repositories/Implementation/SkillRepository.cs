using Microsoft.EntityFrameworkCore;
using Setareh.DAL.Context;
using Setareh.DAL.Entities.skill;
using Setareh.DAL.Repositories.Interface;
using Setareh.DAL.ViewModels.Activity;
using Setareh.DAL.ViewModels.Skill;

namespace Setareh.DAL.Repositories.Implementation
{
    public class SkillRepository : ISkillRepository
    {
        private readonly SetarehContext _context;
        public SkillRepository(SetarehContext context)
        {
            _context = context;
        }
        public async Task<FilterSkillViewModel> FilterAsync(FilterSkillViewModel model)
        {
            var query = _context.Skill.AsQueryable();

            if (!string.IsNullOrEmpty(model.Title))
                query = query.Where(am => EF.Functions.Like(am.Title, $"%{model.Title}%"));

            query = query.OrderByDescending(a => a.CreateDate);

            await model.Paging(query.Select(a => new SkillDetailViewModel
            {
                Title = a.Title,
                CreateDate = a.CreateDate,                                
                Id = a.Id,
                Percentage = a.Percentage
            }));

            return model;
        }

        public async Task<List<SkillDetailViewModel>> GetAllSkills()
        {
            return await _context.Skill.Select(a => new SkillDetailViewModel 
            {
                CreateDate = a.CreateDate,                                
                Title = a.Title,
                Id = a.Id,
                Percentage = a.Percentage
            }).ToListAsync();
        }

        public async Task<Skill?> GetByIdAsync(int id)
        {
            return await _context.Skill.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<EditSkillViewModel?> GetInfoAsync(int id)
        {
            return await _context.Skill.Select(a => new EditSkillViewModel
            {                
                Id = a.Id,                
                Title = a.Title,
                Percentage = a.Percentage
            }).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task InsertAsync(Skill skill)
        {
            await _context.Skill.AddAsync(skill);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Skill skill)
        {
            _context.Skill.Update(skill);
        }
    }
}

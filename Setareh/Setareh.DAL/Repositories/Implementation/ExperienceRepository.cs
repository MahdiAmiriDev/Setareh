using Microsoft.EntityFrameworkCore;
using Setareh.DAL.Context;
using Setareh.DAL.Entities.Expreince;
using Setareh.DAL.Repositories.Interface;
using Setareh.DAL.ViewModels;

namespace Setareh.DAL.Repositories.Implementation
{
    public class ExperienceRepository : IExperienceRepository
    {
        private readonly SetarehContext _context;
        public ExperienceRepository(SetarehContext context)
        {
            _context = context;
        }

        public async Task<EditExperienceViewModel?> EditAsync(EditExperienceViewModel model)
        {
            return await _context.Education.Select(e => new EditExperienceViewModel
            {
                Description = e.Description,
                End = e.End,
                Id = e.Id,
                Start = e.Start,
                Title  = e.Title
            }).FirstOrDefaultAsync(x => x.Id == model.Id);
        }

        public async Task<FilterExperienceViewModel> FilterAsync(FilterExperienceViewModel model)
        {
            var query= _context.Experience.AsQueryable();

            if(!string.IsNullOrEmpty(model.Title))
                query = query.Where(e => e.Title.Contains(model.Title));

            if(model.Start.HasValue)
                query = query.Where(e => e.Start >= model.Start.Value);

            if(model.End.HasValue)
                query = query.Where(e => e.End <= model.End.Value);


            query = query.OrderByDescending(e => e.Start);

            await model.Paging(query.Select(e => new ExperienceViewModel
            {
                End = e.End,
                CreateDate = e.CreateDate,
                Description = e.Description,
                Id = e.Id,
                Start = e.Start,
                Title = e.Title
            }));

            return model;
        }

        public async Task<Experience?> GetByIdAsync(int id)
        {
            return await _context.Experience.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<EditExperienceViewModel> GetForEditbyIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task InsertAsync(Experience model)
        {
            await _context.Experience.AddAsync(model);
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Experience education)
        {
            _context.Update(education);
        }        
    }
}

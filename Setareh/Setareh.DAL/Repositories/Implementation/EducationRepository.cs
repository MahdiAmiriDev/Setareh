using Microsoft.EntityFrameworkCore;
using Setareh.DAL.Context;
using Setareh.DAL.Entities.Education;
using Setareh.DAL.Repositories.Interface;
using Setareh.DAL.ViewModels.Education;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setareh.DAL.Repositories.Implementation
{
    public class EducationRepository : IEducationRepository
    {
        private readonly SetarehContext _context;
        public EducationRepository(SetarehContext context)
        {
            _context = context;
        }

        public async Task<EditEducationViewModel?> EditAsync(EditEducationViewModel model)
        {
            return await _context.Education.Select(e => new EditEducationViewModel
            {
                Description = e.Description,
                End = e.End,
                Id = e.Id,
                Start = e.Start,
                Title  = e.Title
            }).FirstOrDefaultAsync(x => x.Id == model.Id);
        }

        public async Task<FilterEducationViewModel> FilterAsync(FilterEducationViewModel model)
        {
            var query= _context.Education.AsQueryable();

            if(!string.IsNullOrEmpty(model.Title))
                query = query.Where(e => e.Title.Contains(model.Title));

            if(model.Start.HasValue)
                query = query.Where(e => e.Start >= model.Start.Value);

            if(model.End.HasValue)
                query = query.Where(e => e.End <= model.End.Value);


            query = query.OrderByDescending(e => e.Start);

            await model.Paging(query.Select(e => new EducationViewModel
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

        public async Task<Education?> GetByIdAsync(int id)
        {
            return await _context.Education.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<EditEducationViewModel> GetForEditbyIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task InsertAsync(Education model)
        {
            await _context.Education.AddAsync(model);
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Education education)
        {
            _context.Update(education);
        }        
    }
}

using Microsoft.EntityFrameworkCore;
using Setareh.DAL.Context;
using Setareh.DAL.Entities.Acitivity;
using Setareh.DAL.Repositories.Interface;
using Setareh.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setareh.DAL.Repositories.Implementation
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly SetarehContext _context;
        public ActivityRepository(SetarehContext context)
        {
            _context = context;
        }

        public async Task<FilterActivityViewModel> FilterAsync(FilterActivityViewModel model)
        {
            var query = _context.Activity.AsQueryable();

            if (!string.IsNullOrEmpty(model.Title))
                query = query.Where(am => EF.Functions.Like(am.Title, $"%{model.Title}%"));

            query = query.OrderByDescending(a => a.CreateDate);

            await model.Paging(query.Select(a => new ActivityDetailViewModel
            {
                Title = a.Title,
                CreateDate = a.CreateDate,
                Description = a.Description,
                Icon = a.Icon,
                Id = a.Id,

            }));

            return model;
        }

		public async Task<List<ActivityDetailViewModel>> GetAllActivites()
		{
            return await _context.Activity.Select(a => new ActivityDetailViewModel
            {
                CreateDate = a.CreateDate,
                Description = a.Description,
                Icon = a.Icon,
                Title = a.Title,
                Id = a.Id,
            }).ToListAsync();
		}

		public async Task<Activity?> GetByIdAsync(int id)
        {
            return await _context.Activity.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<EditActivityViewModel?> GetInfoAsync(int id)
        {
            return await _context.Activity.Select(a => new EditActivityViewModel
            {
                Description = a.Description,
                Id = a.Id,
                Icon = a.Icon,
                Title = a.Title                 
            }).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task InsertAsync(Activity activity)
        {
           await _context.Activity.AddAsync(activity);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Activity activity)
        {
            _context.Activity.Update(activity);
        }
    }
}

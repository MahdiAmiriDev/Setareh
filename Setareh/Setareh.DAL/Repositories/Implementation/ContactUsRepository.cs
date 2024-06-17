using Microsoft.EntityFrameworkCore;
using Setareh.DAL.Context;
using Setareh.DAL.Entities.ContacUs;
using Setareh.DAL.Repositories.Interface;
using Setareh.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setareh.DAL.Repositories.Implementation
{
    public class ContactUsRepository : IContactUsRepository
    {
        private readonly SetarehContext _context;
        public ContactUsRepository(SetarehContext context)
        {
            _context = context;
        }

        public async Task<FilterContactUsViewModel> FilterAsync(FilterContactUsViewModel model)
        {
            var query = _context.ContactUs.AsQueryable();

            if (!string.IsNullOrEmpty(model.FirstName))
                query = query.Where(cu => EF.Functions.Like(cu.FirstName, $"%{model.FirstName}%"));

            if (!string.IsNullOrEmpty(model.Email))
                query = query.Where(cu => EF.Functions.Like(cu.Email, $"%{model.Email}%"));

            if (!string.IsNullOrEmpty(model.Mobile))
                query = query.Where(cu => EF.Functions.Like(cu.Mobile, $"%{model.Mobile}%"));

            if (!string.IsNullOrEmpty(model.Title))
                query = query.Where(cu => EF.Functions.Like(cu.Title, $"%{model.Title}%"));

            switch (model.AnswerStatus)
            {
                case FilterContactUsAnswerStatus.All:
                    break;
                case FilterContactUsAnswerStatus.Answered:
                    query = query.Where(cu => cu.Answer != null);
                    break;
                case FilterContactUsAnswerStatus.NotAnsered:
                    query = query.Where(cu => cu.Answer == null);
                    break;
            }

            query = query.OrderByDescending(contactUs => contactUs.CreateDate);

            await model.Paging(query.Select(cu => new ContactUsDetailViewModel
            {
                Answer = cu.Answer,
                Id = cu.Id,
                Description = cu.Description,
                Email = cu.Email,
                FirstName = cu.FirstName,
                LastName = cu.LastName,
                Mobile = cu.Mobile,
                Title = cu.Title,
                CreateDate = cu.CreateDate,               
            }));

            return model;
        }

        public async Task<ContactUs?> GetByIdAsync(int id)
        {
            return await _context.ContactUs.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<ContactUsDetailViewModel?> GetInfoByIdAsync(int id)
		{
          return await _context.ContactUs
                .Select(cu => new ContactUsDetailViewModel
                {
                    Answer = cu.Answer,
                    CreateDate = cu.CreateDate,
                    Id = cu.Id,
                    Description = cu.Description,
                    Email = cu.Email,
                    FirstName = cu.FirstName,
                    LastName = cu.LastName,
                    Mobile = cu.Mobile,
                    Title = cu.Title,
                }).FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task InsertAsync(ContactUs model)
        {
            await _context.ContactUs.AddAsync(model);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(ContactUs contactUs)
        {
            _context.ContactUs.Update(contactUs);            
        }
    }
}

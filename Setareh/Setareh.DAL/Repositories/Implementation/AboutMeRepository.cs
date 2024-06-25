using Microsoft.EntityFrameworkCore;
using Setareh.DAL.Context;
using Setareh.DAL.Entities.AboutMe;
using Setareh.DAL.Repositories.Interface;
using Setareh.DAL.ViewModels.AboutMe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setareh.DAL.Repositories.Implementation
{
    public class AboutMeRepository : IAboutMeRepository
    {
        private readonly SetarehContext _context;
        public AboutMeRepository(SetarehContext context)
        {
            _context = context;
        }

        public async Task<AboutMe?> GetAsync()
        {
            return await _context.AboutMe.FirstOrDefaultAsync();
        }

        public async Task<AboutMeViewModel?> GetClientSideInfoAsync()
        {
            return await _context.AboutMe.Select(aboutMe => new AboutMeViewModel
            {
                BirthDate = aboutMe.birthDate,
                Email = aboutMe.Email,
                FirstName = aboutMe.FirstName,
                LastName = aboutMe.LastName,
                Id = aboutMe.Id,
                Location = aboutMe.Location,
                Mobile = aboutMe.Mobile,
                Position = aboutMe.Position,
                Description = aboutMe.Description,
                ImageName = aboutMe.ImageName
            }).FirstOrDefaultAsync();
        }

        public async Task<AboutMeEditModel?> GetInfoAsync()
        {
            return await _context.AboutMe.Select(aboutMe => new AboutMeEditModel
            {
                BirthDate = aboutMe.birthDate,
                Email = aboutMe.Email,
                FirstName = aboutMe.FirstName,
                LastName = aboutMe.LastName,
                Id = aboutMe.Id,
                Location = aboutMe.Location,
                Mobile = aboutMe.Mobile,
                Position = aboutMe.Position,
                Description = aboutMe.Description,
                ImageName = aboutMe.ImageName,
            }).FirstOrDefaultAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(AboutMe aboutMe)
        {
            _context.AboutMe.Update(aboutMe);
        }
    }
}

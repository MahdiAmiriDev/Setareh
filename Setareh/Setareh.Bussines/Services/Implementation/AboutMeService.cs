using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Setareh.Bussines.Services.Interface;
using Setareh.DAL.Repositories.Interface;
using Setareh.DAL.ViewModels;

namespace Setareh.Bussines.Services.Implementation
{
    public class AboutMeService : IAboutMeService
    {
        private readonly IAboutMeRepository _aboutMeRepository;

        public AboutMeService(IAboutMeRepository aboutMeRepository)
        {
            _aboutMeRepository = aboutMeRepository;
        }

        public async Task<AboutMeEditModel?> GetInfoAsync()
        {
            return await _aboutMeRepository.GetInfoAsync();
        }

        public async Task<AboutMeEditResult> UpdateAsync(AboutMeEditModel model)
        {
            var aboutMe = await _aboutMeRepository.GetAsync();

            if (model == null)
                return AboutMeEditResult.NotFound;

            aboutMe.FirstName = model.FirstName;
            aboutMe.LastName = model.LastName;
            aboutMe.birthDate = model.birthDate;
            aboutMe.Mobile = model.Mobile;
            aboutMe.Email = model.Email;
            aboutMe.Location = model.Location;
            aboutMe.Position = model.Position;  

            _aboutMeRepository.Update(aboutMe);
            await _aboutMeRepository.SaveAsync();

            return AboutMeEditResult.Success;
        }
    }
}

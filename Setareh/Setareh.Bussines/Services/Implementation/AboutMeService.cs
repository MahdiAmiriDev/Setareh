using Setareh.Bussines.Services.Interface;
using Setareh.Bussines.Extensions;
using Setareh.DAL.Repositories.Interface;
using Resume.Bussines.Extensions;
using Resume.Bussines.Tools;
using Setareh.DAL.ViewModels.AboutMe;

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
            aboutMe.birthDate = model.BirthDate;
            aboutMe.Mobile = model.Mobile;
            aboutMe.Email = model.Email;
            aboutMe.Location = model.Location;
            aboutMe.Position = model.Position;  
            aboutMe.Description = model.Description;

            if(model.Avatar != null)
            {
                string imageName = Guid.NewGuid() + Path.GetExtension(model.Avatar.FileName);
                model.Avatar.AddImageToServer(imageName,SiteTools.AboutMeAvatar);

                aboutMe.ImageName = imageName;
            }

            _aboutMeRepository.Update(aboutMe);
            await _aboutMeRepository.SaveAsync();

            return AboutMeEditResult.Success;
        }

        public async Task<AboutMeViewModel?> GetClientSideInfoAsync()
        {
            return await _aboutMeRepository.GetClientSideInfoAsync();
        }
    }
}

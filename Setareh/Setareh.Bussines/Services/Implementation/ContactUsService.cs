using Setareh.Bussines.Services.Interface;
using Setareh.DAL.Entities.ContacUs;
using Setareh.DAL.Repositories.Interface;
using Setareh.DAL.ViewModels;
using System.Runtime.CompilerServices;

namespace Setareh.Bussines.Services.Implementation
{
    public class ContactUsService : IContactUsService
    {
        private readonly IContactUsRepository _contactUsRepository;
        public ContactUsService(IContactUsRepository contactUsRepository)
        {
            _contactUsRepository = contactUsRepository;
        }

        public async Task<CreateContactUsResult> CreateAsync(CreateContactUsViewModel model)
        {
            ContactUs contactUs = new()
            {
                Answer = null,
                CreateDate = DateTime.Now,
                Description = model.Description,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Mobile = model.Mobile,
                Title = model.Title
            };

            await _contactUsRepository.InsertAsync(contactUs);
            await _contactUsRepository.SaveAsync();
            return CreateContactUsResult.Success;
        }

        public async Task<FilterContactUsViewModel> FilterAsync(FilterContactUsViewModel model)
        {
            return await _contactUsRepository.FilterAsync(model);
        }
    }
}

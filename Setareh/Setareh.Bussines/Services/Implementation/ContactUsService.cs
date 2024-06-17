using Resume.Bussines.Services.Interfaces;
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
        private readonly IViewRenderService _viewRenderService;
        private readonly IEmailService _emailService;
        public ContactUsService(IContactUsRepository contactUsRepository, IViewRenderService viewRenderService, IEmailService emailService)
        {
            _contactUsRepository = contactUsRepository;
            _viewRenderService = viewRenderService;
            _emailService = emailService;
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

        public async Task<ContactUsDetailViewModel?> GetInfoByIdAsync(int id)
        {
            return await _contactUsRepository.GetInfoByIdAsync(id);
        }

        public async Task<AnswerResult> AnswerAsync(ContactUsDetailViewModel model)
        {
            var contactUs = await _contactUsRepository.GetByIdAsync(model.Id);

            if (contactUs == null)
                return AnswerResult.ContactUsNotFound;

            if (string.IsNullOrEmpty(contactUs.Answer))
                return AnswerResult.AnswerIsNull;

            contactUs.Answer = model.Answer;
            _contactUsRepository.Update(contactUs);
            await _contactUsRepository.SaveAsync();

            string body = await _viewRenderService.RenderToStringAsync("Emails/AnswerContactUs", model);
            await _emailService.SendEmail(contactUs.Email, "پاسخ به تماس با ما", body);

            return AnswerResult.Success;
        }

    }
}

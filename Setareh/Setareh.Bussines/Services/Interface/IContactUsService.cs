using Setareh.DAL.Entities.ContacUs;
using Setareh.DAL.ViewModels.ContactUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setareh.Bussines.Services.Interface
{
    public interface IContactUsService
    {

        Task<CreateContactUsResult> CreateAsync(CreateContactUsViewModel model);

        Task<FilterContactUsViewModel> FilterAsync(FilterContactUsViewModel model);

        Task<ContactUsDetailViewModel?> GetInfoByIdAsync(int id);

        Task<AnswerResult> AnswerAsync(ContactUsDetailViewModel model);

    }
}

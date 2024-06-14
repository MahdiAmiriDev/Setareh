using Setareh.DAL.Entities.ContacUs;
using Setareh.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setareh.DAL.Repositories.Interface
{
    public interface IContactUsRepository
    {
        Task InsertAsync(ContactUs model);

        Task SaveAsync();

        Task<FilterContactUsViewModel> FilterAsync(FilterContactUsViewModel model);
    }
}

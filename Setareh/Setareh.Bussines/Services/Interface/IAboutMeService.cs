using Setareh.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setareh.Bussines.Services.Interface
{
    public interface IAboutMeService
    {
        Task<AboutMeEditModel?> GetInfoAsync();

        Task<AboutMeViewModel?> GetClientSideInfoAsync();

        Task<AboutMeEditResult> UpdateAsync(AboutMeEditModel model);
    }
}

using Setareh.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setareh.Bussines.Services.Interface
{
    public interface IActivityService
    {
        Task<FilterActivityViewModel> FilterAsync(FilterActivityViewModel model);

        Task<CreateActivityResult> CreateAsync(CreateActivityViewModel model);
        Task<EditActivityResult> UpdateAsync(EditActivityViewModel model);
        Task<EditActivityViewModel?> GetInfoByIdAsync(int id);

        Task<List<ActivityDetailViewModel>> GetAllActivitesAsync();
    }
}

using Setareh.DAL.Entities.Education;
using Setareh.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setareh.DAL.Repositories.Interface
{
    public interface IEducationRepository
    {
        Task<FilterEducationViewModel> FilterAsync(FilterEducationViewModel model);

        Task InsertAsync(Education model);

        Task SaveChangeAsync();

        Task<EditEducationViewModel?> EditAsync(EditEducationViewModel model);

        Task<Education?> GetByIdAsync(int id);

        void Update(Education education);

        Task<EditEducationViewModel> GetForEditbyIdAsync(int id);

    }
}

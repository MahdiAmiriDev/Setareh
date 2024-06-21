using Setareh.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setareh.DAL.Repositories.Interface
{
    public interface IActivityRepository
    {
        Task<FilterActivityViewModel> FilterAsync(FilterActivityViewModel model);
    }
}

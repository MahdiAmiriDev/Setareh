using Microsoft.AspNetCore.Mvc;
using Setareh.Bussines.Services.Interface;
using Setareh.DAL.ViewModels;
using System.Runtime.CompilerServices;

namespace Setareh.Web.Areas.Admin.Controllers
{
    public class ActivityController : AdminBaseController
    {
        private readonly IActivityService _activityService;
        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        public async Task<IActionResult> List(FilterActivityViewModel model)
        {
            var data = await _activityService.FilterAsync(model);

            return View(data);
        }
    }
}

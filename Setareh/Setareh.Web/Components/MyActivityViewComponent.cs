using Microsoft.AspNetCore.Mvc;
using Setareh.Bussines.Services.Interface;

namespace Setareh.Web.Components
{
	public class MyActivityViewComponent: ViewComponent
	{
		private readonly IActivityService _activityService;
		public MyActivityViewComponent(IActivityService activityService)
		{
			_activityService = activityService;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var model = await _activityService.GetAllActivitesAsync();
				return View("MyActivity", model);
		}
	}
}

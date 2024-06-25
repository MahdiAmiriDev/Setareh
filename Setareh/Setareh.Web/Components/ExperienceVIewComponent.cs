using Microsoft.AspNetCore.Mvc;
using Setareh.Bussines.Services.Interface;
using Setareh.DAL.ViewModels.Experience;

namespace Setareh.Web.Components
{
	public class ExperienceViewComponent : ViewComponent
	{
		private readonly IExperienceService _experienceService;
		public ExperienceViewComponent(IExperienceService experienceService)
		{
			_experienceService = experienceService;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var model = await _experienceService.FilterAsync(new FilterExperienceViewModel
			{

			});

			return View("Experience",model);
		}
	}
}

using Microsoft.AspNetCore.Mvc;
using Setareh.Bussines.Services.Interface;
using Setareh.DAL.ViewModels.Education;

namespace Setareh.Web.Components
{
	public class EducationViewComponent: ViewComponent
	{
		private readonly IEducationService _educationService;
		public EducationViewComponent(IEducationService educationService)
		{
			_educationService = educationService;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var model = await _educationService.FilterAsync(new FilterEducationViewModel
			{

			});

			return View("Education",model);
		}
	}
}

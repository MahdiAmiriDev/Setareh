using Microsoft.AspNetCore.Mvc;
using Setareh.Bussines.Services.Interface;

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
			var model = await _educationService.FilterAsync(new DAL.ViewModels.FilterEducationViewModel
			{

			});

			return View("Education",model);
		}
	}
}

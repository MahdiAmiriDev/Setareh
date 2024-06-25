using Microsoft.AspNetCore.Mvc;
using Setareh.Bussines.Services.Interface;

namespace Setareh.Web.Components
{
	public class EducationVIewComponent: ViewComponent
	{
		private readonly IEducationService _educationService;
		public EducationVIewComponent(IEducationService educationService)
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

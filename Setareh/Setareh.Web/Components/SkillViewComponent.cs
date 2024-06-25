using Microsoft.AspNetCore.Mvc;
using Setareh.Bussines.Services.Interface;

namespace Setareh.Web.Components
{
	public class SkillViewComponent: ViewComponent
	{
		private readonly ISkillService _skillService;
		public SkillViewComponent(ISkillService skillService)
		{
            _skillService = skillService;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var model = await _skillService.GetAllSkillsAsync();

			return View("Skill",model);
		}
	}
}

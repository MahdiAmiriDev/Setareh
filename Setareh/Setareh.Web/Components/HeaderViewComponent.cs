using Microsoft.AspNetCore.Mvc;
using Setareh.Bussines.Services.Interface;

namespace Setareh.Web.Components
{
	public class HeaderViewComponent:ViewComponent
	{
		#region Feilds

		private readonly IAboutMeService _aboutMeService;

        public HeaderViewComponent(IAboutMeService aboutMeService)
        {
            _aboutMeService = aboutMeService;
        }

        #endregion

        #region Ctor
        #endregion

        #region Methods
        public async Task<IViewComponentResult> InvokeAsync()
		{	
            var model = await _aboutMeService.GetClientSideInfoAsync();

			return View("Header",model);
		}

		#endregion


	}
}

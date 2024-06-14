using Microsoft.AspNetCore.Mvc;
using Setareh.Bussines.Extensions;
using Setareh.Bussines.Services.Interface;

namespace Setareh.Web.Areas.Admin.Components
{
    public class LeftSideBarViewComponent:ViewComponent
    {

        private readonly IUserService _userService;
		public LeftSideBarViewComponent(IUserService userService)
		{
			_userService = userService;
		}

		#region Methods

		public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewData["User"] = await _userService.GetUserInformationAsync(User.GetUserId());

            return View("LeftSideBar");
        }
        
        #endregion
    }
}

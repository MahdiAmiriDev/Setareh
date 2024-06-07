using Microsoft.AspNetCore.Mvc;

namespace Setareh.Web.Components
{
	public class HeaderViewComponent:ViewComponent
	{
		#region Feilds
		#endregion

		#region Ctor
		#endregion

		#region Methods
		public async Task<IViewComponentResult> InvokeAsync()
		{	

			return View("Header");
		}

		#endregion


	}
}

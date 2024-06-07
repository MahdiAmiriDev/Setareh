using Microsoft.AspNetCore.Mvc;

namespace Setareh.Web.Areas.Admin.Controllers
{
    public class HomeController:AdminBaseController
    {
        #region Actions

        public IActionResult Index()
        {
            return View();
        }

        #endregion
    }
}

using Microsoft.AspNetCore.Mvc;

namespace Setareh.Web.Controllers
{
    public class ResumeController:SiteBaseController
    {
        [Route("/resume")]
        public IActionResult Index()
        {
            return View();
        }
    }
}

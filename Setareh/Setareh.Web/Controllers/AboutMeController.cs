using Microsoft.AspNetCore.Mvc;
using Setareh.Bussines.Services.Interface;

namespace Setareh.Web.Controllers
{
    public class AboutMeController : SiteBaseController
    {
        private readonly IAboutMeService _aboutMeService;
        public AboutMeController(IAboutMeService aboutMeService)
        {
            _aboutMeService = aboutMeService;
        }

        [Route("/")]
        public async Task<IActionResult> Index()
        {
            var model = await _aboutMeService.GetClientSideInfoAsync();

            return View(model);
        }
    }
}

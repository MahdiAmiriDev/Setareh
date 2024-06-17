using Microsoft.AspNetCore.Mvc;
using Setareh.Bussines.Services.Interface;
using Setareh.DAL.ViewModels;

namespace Setareh.Web.Areas.Admin.Controllers
{
    public class AboutMeController : AdminBaseController
    {
        private readonly IAboutMeService _aboutMeService;
        public AboutMeController(IAboutMeService aboutMeService)
        {
            _aboutMeService = aboutMeService;
        }

        public async Task<IActionResult> Edit()
        {
            var result = await _aboutMeService.GetInfoAsync();

            if (result == null)
                return NotFound();

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AboutMeEditModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

             

            return View();
        }
    }
}

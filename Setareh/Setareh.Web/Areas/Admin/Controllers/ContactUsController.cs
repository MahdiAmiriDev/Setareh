using Microsoft.AspNetCore.Mvc;
using Setareh.Bussines.Services.Interface;
using Setareh.DAL.ViewModels;

namespace Setareh.Web.Areas.Admin.Controllers
{
    public class ContactUsController : AdminBaseController
    {
        private readonly IContactUsService _contactUsService;
        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        public async Task<IActionResult> List(FilterContactUsViewModel filterModel)
        {
            var model = await _contactUsService.FilterAsync(filterModel);

            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var contactUs = await _contactUsService.GetByIdAsync(id);

            if(contactUs == null)
                return NotFound();

            return View(contactUs);
        }
    }
}

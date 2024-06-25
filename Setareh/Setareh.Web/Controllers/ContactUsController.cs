using Microsoft.AspNetCore.Mvc;
using Setareh.Bussines.Services.Implementation;
using Setareh.Bussines.Services.Interface;
using Setareh.DAL.ViewModels.ContactUs;

namespace Setareh.Web.Controllers
{
    public class ContactUsController : SiteBaseController
    {
        private readonly IContactUsService _contactUsService;
        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        [HttpGet("/ContactUs")]
        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost("/ContactUs")]
        public async Task<IActionResult> ContactUs(CreateContactUsViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _contactUsService.CreateAsync(model);

            switch (result)
            {
                case CreateContactUsResult.Success:
                    TempData[SuccessMessage] = "پیام شما با موفقیت ثبت شد.";
                    return RedirectToAction("ContactUs");
                case CreateContactUsResult.Error:
                    TempData[SuccessMessage] = "بروز خطا به هنگام افزودن پیام شما.";
                    break;
            }

            return View(model);
        }
    }
}

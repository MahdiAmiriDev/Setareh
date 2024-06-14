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

        [HttpPost("/ContactUs")]
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

        public async Task<IActionResult> List(FilterContactUsViewModel filterModel)
        {
            var model = await _contactUsService.FilterAsync(filterModel);

            return View(model);
        }
    }
}

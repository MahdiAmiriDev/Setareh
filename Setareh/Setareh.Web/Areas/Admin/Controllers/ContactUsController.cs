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

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var contactUs = await _contactUsService.GetInfoByIdAsync(id);

            if(contactUs == null)
                return NotFound();

            return View(contactUs);
        }

        [HttpPost]
        public async Task<IActionResult> Details(ContactUsDetailViewModel model)
        {
            if(!ModelState.IsValid)
                return View(model);

            var result = await _contactUsService.AnswerAsync(model);

            switch (result)
            {
                case AnswerResult.Success:
                    TempData[SuccessMessage] = "پاسخ شما با موفقیت ثبت شد ";
                    return RedirectToAction("List");                    
                case AnswerResult.ContactUsNotFound:
                    TempData[ErrorMessage] = " آبجکت موردنظر یافت نشد";
                    return RedirectToAction("List");                    
                case AnswerResult.Error:
                    TempData[ErrorMessage] = "  بروز خطا در طول انجام عملیات";

                    return RedirectToAction("List");
                case AnswerResult.AnswerIsNull:
                    TempData[ErrorMessage] = "متن پاسخ خالی است ";
                    return RedirectToAction("List");
            }

            return View(model);
        }
    }
}

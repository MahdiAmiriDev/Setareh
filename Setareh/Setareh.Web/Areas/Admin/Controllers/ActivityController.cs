using Microsoft.AspNetCore.Mvc;
using Setareh.Bussines.Services.Interface;
using Setareh.DAL.ViewModels.Activity;


namespace Setareh.Web.Areas.Admin.Controllers
{
    public class ActivityController : AdminBaseController
    {
        private readonly IActivityService _activityService;
        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        public async Task<IActionResult> List(FilterActivityViewModel model)
        {
            var data = await _activityService.FilterAsync(model);

            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateActivityViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _activityService.CreateAsync(model);

            switch (result)
            {
                case CreateActivityResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد.";
                    return RedirectToAction("List");

                case CreateActivityResult.Error:
                    TempData[ErrorMessage] = "بروز خطا به هنگام انجام عملیات";
                    break;
            }

            return View(model);
        }

        public async Task<IActionResult> Update(int id)
        {
            var model = await _activityService.GetInfoByIdAsync(id);

            if (model == null)
                return NotFound();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(EditActivityViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _activityService.UpdateAsync(model);

            switch (result)
            {
                case EditActivityResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد.";
                    return RedirectToAction("List");

                case EditActivityResult.Error:
                    TempData[ErrorMessage] = "بروز خطا به هنگام انجام عملیات";
                    break;

                case EditActivityResult.NotFound:
                    TempData[ErrorMessage] = "ایتم مورد نظر یافت نشد";
                    break;
            }

            return View(model);
        }
    }
}

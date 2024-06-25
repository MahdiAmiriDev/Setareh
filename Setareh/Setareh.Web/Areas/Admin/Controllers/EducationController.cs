using Microsoft.AspNetCore.Mvc;
using Setareh.Bussines.Services.Interface;
using Setareh.DAL.ViewModels.Activity;
using Setareh.DAL.ViewModels.Education;

namespace Setareh.Web.Areas.Admin.Controllers
{
    public class EducationController : AdminBaseController
    {
        private readonly IEducationService _educationService;
        public EducationController(IEducationService educationService)
        {
            _educationService = educationService;
        }
        
        public async Task<IActionResult> List(FilterEducationViewModel filter)
        {
            var model = await _educationService.FilterAsync(filter);
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEducationViewModel model)
        {
            if(!ModelState.IsValid)
                return View(model);

            var result = await _educationService.Create(model);

            switch (result)
            {
                case CreateActivityResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
                    return RedirectToAction("List");                    
                case CreateActivityResult.Error:
                    TempData[ErrorMessage] = "بروز خطا";
                    break;                
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await _educationService.GetForEditbyIdAsync(id);

            if (model == null)
                return NotFound();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditEducationViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _educationService.EditAsync(model);

            switch (result)
            {
                case EditEducationResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
                    return RedirectToAction("List");
                case EditEducationResult.Error:
                    TempData[ErrorMessage] = "بروز خطا";
                    break;
                case EditEducationResult.NotFound:
                    TempData[ErrorMessage] = "ایتم موردنظر یافت نشد";
                    break;
            }

            return View(model);
        }
    }
}

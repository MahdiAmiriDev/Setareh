using Microsoft.AspNetCore.Mvc;
using Setareh.Bussines.Services.Interface;
using Setareh.DAL.ViewModels.Activity;
using Setareh.DAL.ViewModels.Experience;

namespace Setareh.Web.Areas.Admin.Controllers
{
    public class ExperienceController : AdminBaseController
    {
        private readonly IExperienceService _experienceService;
        public ExperienceController(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }
        
        public async Task<IActionResult> List(FilterExperienceViewModel filter)
        {
            var model = await _experienceService.FilterAsync(filter);
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateExperienceViewModel model)
        {
            if(!ModelState.IsValid)
                return View(model);

            var result = await _experienceService.Create(model);

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
            var model = await _experienceService.GetForEditbyIdAsync(id);

            if (model == null)
                return NotFound();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditExperienceViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _experienceService.EditAsync(model);

            switch (result)
            {
                case EditExperienceResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
                    return RedirectToAction("List");
                case EditExperienceResult.Error:
                    TempData[ErrorMessage] = "بروز خطا";
                    break;
                case EditExperienceResult.NotFound:
                    TempData[ErrorMessage] = "ایتم موردنظر یافت نشد";
                    break;
            }

            return View(model);
        }
    }
}

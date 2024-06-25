using Microsoft.AspNetCore.Mvc;
using Setareh.Bussines.Services.Implementation;
using Setareh.Bussines.Services.Interface;
using Setareh.DAL.ViewModels.Activity;
using Setareh.DAL.ViewModels.Skill;

namespace Setareh.Web.Areas.Admin.Controllers
{
    public class SkillController : AdminBaseController
    {
        private readonly ISkillService _skillService;
        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        public async Task<IActionResult> List(FilterSkillViewModel model)
        {
            var data = await _skillService.FilterAsync(model);

            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSkillViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _skillService.CreateAsync(model);

            switch (result)
            {
                case CreateSkillResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد.";
                    return RedirectToAction("List");

                case CreateSkillResult.Error:
                    TempData[ErrorMessage] = "بروز خطا به هنگام انجام عملیات";
                    break;
            }

            return View(model);
        }

        public async Task<IActionResult> Update(int id)
        {
            var model = await _skillService.GetInfoByIdAsync(id);

            if (model == null)
                return NotFound();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(EditSkillViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _skillService.UpdateAsync(model);

            switch (result)
            {
                case EditSkillResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد.";
                    return RedirectToAction("List");

                case EditSkillResult.Error:
                    TempData[ErrorMessage] = "بروز خطا به هنگام انجام عملیات";
                    break;

                case EditSkillResult.NotFound:
                    TempData[ErrorMessage] = "ایتم مورد نظر یافت نشد";
                    break;
            }

            return View(model);
        }
    }
}

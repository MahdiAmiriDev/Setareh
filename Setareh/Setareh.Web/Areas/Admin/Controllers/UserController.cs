using Microsoft.AspNetCore.Mvc;
using Setareh.Bussines.Services.Interface;
using Setareh.DAL.Entities.User;
using Setareh.DAL.ViewModels.User;

namespace Setareh.Web.Areas.Admin.Controllers
{
    public class UserController : AdminBaseController
    {
        #region Fields

        private readonly IUserService _userService;

        #endregion

        #region Constractor

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region Methods

        #region List

        public async Task<IActionResult> List(UserFilterViewModel filter)
        {
            var result = await _userService.FilterAsync(filter);
            return View(result);
        }

        #endregion

        #region Create

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _userService.CreateUserAsync(model);

            switch (result)
            {
                case CreateUserResult.Success:
                    TempData[SuccessMessage] = "کاربر جدید با موفقیت افزوده شد.";
                    return RedirectToAction("List");                     
                case CreateUserResult.Error:
                    TempData[ErrorMessage] = "کاربر گرامی در طول انجام فرآیند خطایی رخ داده است";
                    break;
            }

            return View(model);
        }

        #endregion

        #region Update

        public async Task<IActionResult> Update(int id)
        {
            var user = await _userService.GetForEditByIdAsync(id);

            if (user == null)
                return NotFound();

            

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserEditModel model)
        {
            if (!ModelState.IsValid)
                return View(model);


            var result = await _userService.UpdateAsync(model);

            switch (result)
            {
                case EditUserResult.Success:
                    TempData[SuccessMessage] = "کاربر جدید با موفقیت ویرایش شد.";
                    return RedirectToAction("List");
                case EditUserResult.Error:
                    TempData[ErrorMessage] = "کاربر گرامی در طول انجام فرآیند خطایی رخ داده است";
                    break;
                case EditUserResult.UserNotFound:
                    TempData[ErrorMessage] = "کاربر موردنظز پیدا نشد";
                    break;
                case EditUserResult.EmailDuplicated:
                    TempData[ErrorMessage] = "بروز خطا ایمیل تکراری است";
                    break;
                case EditUserResult.MobileDuplicated:
                    TempData[ErrorMessage] = "بروز خطا شماره موبایل تکراری است";
                    break;
            }


            return View(model);
        }

        #endregion

        #endregion
    }
}

using Microsoft.AspNetCore.Mvc;
using Setareh.Bussines.Services.Interface;
using Setareh.DAL.Entities.User;
using Setareh.DAL.ViewModels;

namespace Setareh.Web.Areas.Admin.Controllers
{
    public class UserController : Controller
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
                    break;
                case CreateUserResult.Error:
                    break;
            }

            return View();
        }

        #endregion

        #region Update

        public async Task<IActionResult> Update(int id)
        {
            var user = await _userService.GetForEditByIdAsync(id);

            if (user == null)
                return NotFound();

            

            return View();
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
                    break;
                case EditUserResult.Error:
                    break;
                case EditUserResult.UserNotFound:
                    break;
                case EditUserResult.EmailDuplicated:
                    break;
                case EditUserResult.MobileDuplicated:
                    break;
            }


            return View();
        }

        #endregion

        #endregion
    }
}

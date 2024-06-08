using Microsoft.AspNetCore.Mvc;
using Setareh.Bussines.Services.Interface;
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

        public Task<IActionResult> List()
        {
            return View();
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


            return View();
        }

        #endregion

        #region Update

        public async Task<IActionResult> Update(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserEditModel model)
        {
            if (!ModelState.IsValid)
                return View(model);


            return View();
        }

        #endregion

        #endregion
    }
}

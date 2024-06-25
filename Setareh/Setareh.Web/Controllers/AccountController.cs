using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Setareh.Bussines.Services.Interface;
using Setareh.DAL.Entities.Account;
using System.Security.Claims;

namespace Setareh.Web.Controllers
{
    public class AccountController : SiteBaseController
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("/login")]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home", new { area = "Admin" });


            return View();
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _userService.LoginAsync(model);

            switch (result)
            {
                case LoginResult.Success:
                    var user = await _userService.GetByEmailAsync(model.Email);
                    var claims = new List<Claim>() 
                    {
                         new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                         new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                         new Claim(ClaimTypes.MobilePhone, user.Mobile)
                    };

                    var identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme); ;
                    var principal = new ClaimsPrincipal(identity);

                    var properties = new AuthenticationProperties
                    {
                        IsPersistent = true
                    };

                    await HttpContext.SignInAsync(principal, properties);

                    TempData[SuccessMessage] = "خوش آمدید";

                    return RedirectToAction("Index", "Home", new { area = "Admin" });                    

                case LoginResult.Error:
                    ViewData[ErrorMessage] = "بروز خطا لطفا مچددا تلاس کنید";
                    return View(model);

                case LoginResult.UserNotFound:
                    ViewData[ErrorMessage] = "کاربری یافت نشد";
                    return View(model);
                    
            }


            return View(model);
        }

        [HttpGet("/logout")]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}

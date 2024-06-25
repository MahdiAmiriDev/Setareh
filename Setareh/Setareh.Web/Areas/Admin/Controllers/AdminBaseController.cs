using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Setareh.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AdminBaseController:Controller
    {
        protected string SuccessMessage = "SuccessMessage";
        protected string ErrorMessage = "ErrorMessage";
    }
}

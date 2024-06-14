using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Principal;

namespace Setareh.Bussines.Extensions
{
	public static class Identity
	{
		public static int GetUserId(this ClaimsPrincipal principal)
		{
			if (principal == null)
				return default;

			if(principal.FindFirst(ClaimTypes.NameIdentifier) == null)
				return default;

			string? userId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

			if(userId.IsNullOrEmpty())
				return default;
			else
				return int.Parse(userId);
		}

		public static int GetUserId(this IPrincipal principal)
		{
			if (principal == null)
				return default;

			var user = (ClaimsPrincipal)principal;

			return user.GetUserId();
		}
	}
}

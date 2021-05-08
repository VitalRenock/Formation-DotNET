using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using _04ModelClient.Services;

namespace _05AspMvc.Tools.Validation.AuthAttributes
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
	public class AdminRightAttribute : AuthorizeAttribute
	{
		protected override bool AuthorizeCore(HttpContextBase httpContext)
		{
			UserClientService _userClientService = new UserClientService();

			// Vérifie si l'utilisateur à des droits
			if (Utils.SessionUser is null)
				return false;

			// Vérifie via les services si Admin
			if (_userClientService.HaveAdminRight(Utils.SessionUser.Id))
				return true;
			else
				return false;
		}

		// Redirige l'utilisateur vers la page 'Login' si il ne possède pas les droits.
		protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
		{
			filterContext.Result =
			new RedirectToRouteResult(
				new RouteValueDictionary
				{
					{"action", "Login" },
					{"controller", "UserAsp" },
					{"Area", string.Empty }
				});
		}
	}
}
using _04ModelClient.Data;
using _04ModelClient.Services;
using _05AspMvc.Models.Views;
using _05AspMvc.Tools.Mappers;
using _05AspMvc.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _05AspMvc.Models;
using _05AspMvc.Tools;
using _05AspMvc.Tools.Validation.AuthAttributes;

namespace _05AspMvc.Controllers
{
    public class UserAspController : Controller
    {
        private UserClientService _userService = new UserClientService();

		#region Index

		public ActionResult Index()
		{
			return View();
		}

		#endregion

		#region Anonymous User

		#region Register
		
		[AnonymousUser]
		public ActionResult Register()
		{
			UserAspRegister data = new UserAspRegister();
			return View(data);
		}

		[AnonymousUser]
		[HttpPost]
		public ActionResult Register(UserAspRegister form)
		{
			try
			{
				if (!ModelState.IsValid) throw new Exception();
				UserClient data = form.ToClient();
				int id = _userService.Add(data);
				ViewBag.id = id;
				return RedirectToAction("Login");
			}
			catch (Exception)
			{
				return View(form);
			}
		}

		#endregion

		#region Login
		
		[AnonymousUser]
		public ActionResult Login()
		{
			UserAspLogin form = new UserAspLogin();
			return View(form);
		}

		[AnonymousUser]
		[HttpPost]
		public ActionResult Login(UserAspLogin form)
		{
			try
			{
				ViewBag.Success = true;
				ViewBag.Message = "Success";
				if (!ModelState.IsValid) throw new Exception();
				int? id = _userService.CheckPassword(form.Mail, form.Password);
				if (id is null) throw new Exception();
				UserAsp user = _userService.GetbyId((int)id).ToMvc();
				Utils.SessionUser = user;
				return RedirectToAction("Index");
			}
			catch (Exception)
			{
				ViewBag.Success = false;
				ViewBag.Message = "Failed";
				return View(form);
			}
		}
		
		#endregion

		#endregion

		#region Authentified User

		#region LogOut

		[AuthentifiedUser]
		public ActionResult LogOut()
		{
			Session.Abandon();
			return RedirectToAction("Login");
		}

		#endregion

		#endregion
	}
}
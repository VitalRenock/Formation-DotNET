using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ExoASPUser.Mapper;
using ExoASPUser.Models;
using ModelClient.Services;

namespace ExoASPUser.Controllers
{
    public class UserController : Controller
    {
		#region Properties
		
        private UserClientService userClientService = new UserClientService();

		#endregion

		#region Index
		
        // GET: User
		public ActionResult Index()
		{
			return View(userClientService.GetAll().Select(u => u.ToMvc()));
		}

		#endregion

		#region Details
		
        // GET: User/Details/5
		public ActionResult Details(int id)
		{
            return View(userClientService.GetById(id).ToMvc());
        }

		#endregion

		#region Create
		
        // GET: User/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: User/Create
		[HttpPost]
		public ActionResult Create(UserMvc user)
		{
			if (!ModelState.IsValid)
                return View();

            userClientService.Add(user.ToClient());
            return RedirectToAction("Index");
        }

		#endregion

		#region Edit
		
		// GET: User/Edit/5
		public ActionResult Edit(int id)
		{
			return View(userClientService.GetById(id).ToMvc());
		}

		// POST: User/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, UserMvc user)
		{
			if (ModelState.IsValid)
			{
				bool result = userClientService.Edit(id, user.ToClient());

				if (result)
					return RedirectToAction("Index");
				else
					return View();
			}
			else
				return View();
		}

		#endregion

		#region Delete

		// GET: User/Delete/5
		public ActionResult Delete(int id)
		{
			return View(userClientService.GetById(id).ToMvc());
		}

		// POST: User/Delete/5
		[HttpPost]
		public ActionResult Delete(int id, UserMvc user)
		{
			try
			{
				bool result = userClientService.Delete(id);

				if (result)
					return RedirectToAction("Index");
				else
					return View();
			}
			catch
			{
				return View();
			}
		}

		#endregion
	}
}

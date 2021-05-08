using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using _04ModelClient.Data;
using _04ModelClient.Services;
using _05AspMvc.Areas.Admin.Data;
using _05AspMvc.Tools.Mappers;
using _05AspMvc.Tools.Validation.AuthAttributes;

namespace _05AspMvc.Areas.Admin.Controllers
{
    [AdminRight]
    public class AdminController : Controller
    {
        private UserClientService _userService = new UserClientService();

        public ActionResult Index()
        {
            IEnumerable<AspUserRight> datas = _userService.GetAll().Select(user => new AspUserRight(user.ToMvc()));
            return View(datas);
        }

        public ActionResult ToogleAdminRight(int id)
		{
			if (_userService.HaveAdminRight(id))
                _userService.DenyAdmin(id);
			else
                _userService.GrantAdmin(id);
            return RedirectToAction("Index");
		}

        public ActionResult ToogleDefaultRight(int id)
        {
            if (_userService.HaveDefaultRight(id))
                _userService.DenyDefault(id);
            else
                _userService.GrantDefault(id);
            
            return RedirectToAction("Index");
        }
    }
}
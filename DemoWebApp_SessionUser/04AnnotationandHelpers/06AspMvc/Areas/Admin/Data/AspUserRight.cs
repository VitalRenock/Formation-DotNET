using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

using _04ModelClient.Services;
using _05AspMvc.Models;

namespace _05AspMvc.Areas.Admin.Data
{
	public class AspUserRight
	{
		private UserClientService _userClientService;

        public int Id { get; set; }
        [Display(Name= "Adresse électronique")]
        public string Mail { get; set; }
        [Display(Name= "Nom")]
        public string LastName { get; set; }
        [Display(Name= "Prénom")]
        public string FirstName { get; set; }
		public bool IsAdmin { get => _userClientService.HaveAdminRight(this.Id); }
		public bool IsDefault { get => _userClientService.HaveDefaultRight(this.Id); }

		#region Constructors
		
		public AspUserRight()
		{
			_userClientService = new UserClientService();
		}

		public AspUserRight(UserAsp user)
		{
			Id = user.Id;
			Mail = user.Mail;
			LastName = user.LastName;
			FirstName = user.FirstName;

		}


		#endregion

		public void ToogleAdminRight()
		{
			if (this.IsAdmin)
				_userClientService.DenyAdmin(this.Id);
			else
				_userClientService.GrantAdmin(this.Id);
		}
		public void ToogleDefaultRight()
		{
			if (this.IsDefault)
				_userClientService.DenyDefault(this.Id);
			else
				_userClientService.GrantDefault(this.Id);
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ExoASPUser.Models;
using ModelClient.Data;

namespace ExoASPUser.Mapper
{
	public static class Mapper
	{
		#region User

		public static UserMvc ToMvc(this UserClient user)
		{
			return new UserMvc(
				user.Id,
				user.Email,
				user.Password,
				user.Lastname,
				user.Firstname,
				user.Birthdate,
				user.NationalRegister,
				user.Biography
				);
		}

		public static UserClient ToClient(this UserMvc user)
		{
			return new UserClient(
				user.Id,
				user.Email,
				user.Password,
				user.Lastname,
				user.Firstname,
				user.Birthdate,
				user.NationalRegister,
				user.Biography
				);
		}
		public static UserClient ToClientNoID(this UserMvc user)
		{
			return new UserClient(
				user.Email,
				user.Password,
				user.Lastname,
				user.Firstname,
				user.Birthdate,
				user.NationalRegister,
				user.Biography
				);
		}

		#endregion
	}
}
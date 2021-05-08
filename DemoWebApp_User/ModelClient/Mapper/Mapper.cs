using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModelClient.Data;
using ModelGlobal.Data;

namespace ModelClient.Mapper
{
	internal static class Mapper
	{
		#region User

		internal static UserGlobal ToGlobal(this UserClient user)
		{
			return new UserGlobal(
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

		internal static UserClient ToClient(this UserGlobal user)
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

		#endregion
	}
}

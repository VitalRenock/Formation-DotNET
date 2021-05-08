using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelGlobal.Data
{
	/// <summary>
	/// Modèle pour la communication entre la base de donnée et le modèle client.
	/// </summary>
	public class UserGlobal
	{
		#region Properties
		
		public int Id { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Lastname { get; set; }
		public string Firstname { get; set; }
		public DateTime Birthdate { get; set; }
		public string NationalRegister { get; set; }
		public string Biography { get; set; }

		#endregion

		#region Constructors

		public UserGlobal()
		{

		}

		public UserGlobal(string email, string password, string lastname, string firstname, DateTime birthdate, string nationalRegister, string biography)
		{
			Email = email;
			Password = password;
			Lastname = lastname;
			Firstname = firstname;
			Birthdate = birthdate;
			NationalRegister = nationalRegister;
			Biography = biography;
		}

		public UserGlobal(int id, string email, string password, string lastname, string firstname, DateTime birthdate, string nationalRegister, string biography)
		{
			Id = id;
			Email = email;
			Password = password;
			Lastname = lastname;
			Firstname = firstname;
			Birthdate = birthdate;
			NationalRegister = nationalRegister;
			Biography = biography;
		}

		#endregion
	}
}

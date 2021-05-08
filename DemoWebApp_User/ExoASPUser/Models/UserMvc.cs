using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace ExoASPUser.Models
{
	public class UserMvc
	{
		#region Properties

		public int Id { get; set; }
		[Required]
		[EmailAddress]
		public string Email { get; set; }
		[Required]
		[DataType(DataType.Password)]
		[RegularExpression(@"^(?=.*\d)(?=.*[A-Z])(?=.*[-#@_]).{8,32}$", ErrorMessage = "Le mot de passe doit contenir au minimum 8 caractères : dont une majuscule, un chiffre et un caractère spécial (@, #, -,_)")]
		public string Password { get; set; }
		// Add confirmed password
		[Required]
		public string Lastname { get; set; }
		[Required]
		public string Firstname { get; set; }
		[Required]
		[DataType(DataType.Date)]
		public DateTime Birthdate { get; set; }
		[Required]
		[RegularExpression(@"^5[1-5][0-9]{14}$", ErrorMessage = "Format du registre invalide.")]
		public string NationalRegister { get; set; }
		[Required]
		[DataType(DataType.MultilineText)]
		[StringLength(120, ErrorMessage = "Le texte ne peut dépasser 120 caractères.")]
		public string Biography { get; set; }

		#endregion

		#region Constructors

		public UserMvc()
		{

		}

		public UserMvc(string email, string password, string lastname, string firstname, DateTime birthdate, string nationalRegister, string biography)
		{
			Email = email;
			Password = password;
			Lastname = lastname;
			Firstname = firstname;
			Birthdate = birthdate;
			NationalRegister = nationalRegister;
			Biography = biography;
		}

		public UserMvc(int id, string email, string password, string lastname, string firstname, DateTime birthdate, string nationalRegister, string biography)
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
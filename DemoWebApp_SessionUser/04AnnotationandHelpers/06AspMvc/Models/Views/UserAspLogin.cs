using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _05AspMvc.Models.Views
{
    public class UserAspLogin
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Identifiant", Prompt = "Adresse e-mail")]
        public string Mail { get; set; }
        [Required]
        [Display(Name = "Mot de passe")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
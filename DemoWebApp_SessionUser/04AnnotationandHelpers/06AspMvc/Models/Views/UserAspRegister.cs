using _05AspMvc.Tools.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _05AspMvc.Models.Views
{
    public class UserAspRegister
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Email *")]
        [EmailAddress]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Mail { get; set; }
        [Required]
        [Display(Name = "Mot de passe *")]
        [StringLength(32, MinimumLength = 8, ErrorMessage = "La longueur du mot de passe doit être comprise entre 8 et 32.")]
        [RegularExpression(@"^(?=.*\d)(?=.*[A-Z])(?=.*[-#@_]).{8,32}$", ErrorMessage = "Le mot de passe doit contenir au minimum 8 caractères : dont une majuscule, un chiffre et un caractère spécial (@, #, -,_)")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Confirmation du mot de passe *")]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmedPassword { get; set; }
        [Required]
        [Display(Name = "Nom *")]
        [RegularExpression(@"[A-Za-z -']*")]
        [MaxLength(64)]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Prénom *")]
        [RegularExpression(@"[A-Za-z -']*")]
        [MaxLength(64)]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Date de naissance *")]
        [DataType(DataType.Date)]
        [CustomValidationDate]
        public DateTime BirthDate { get; set; }
        [Required]
        [Display(Name = "N° de registre National *")]
        [RegularExpression(@"\d{11,11}", ErrorMessage = "Le n° de registre national doit être composé de 11 numéro.")]
        [CustomValidationRegNational(nameof(BirthDate))]
        public string RegNational { get; set; }
        [Display(Name = "Biographie (Max 120 caractères)")]
        [DataType(DataType.MultilineText)]
        [MaxLength(120)]
        public string Bio { get; set; }
    }
}
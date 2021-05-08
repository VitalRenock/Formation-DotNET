using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _05AspMvc.Tools.Validation
{
    public class CustomValidationRegNationalAttribute : ValidationAttribute
    {
        private string _fieldName;
        public CustomValidationRegNationalAttribute(string fieldName)
        {
            _fieldName = fieldName;
        }
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if (value is null) return new ValidationResult("Le registre est null.");
            string year = value.ToString().Substring(0, 2);
            string month = value.ToString().Substring(2, 2);
            string day = value.ToString().Substring(4, 2);
            int y, m, d;
            if (!int.TryParse(year, out y)) return new ValidationResult("Le format est incorrect");
            if (!int.TryParse(month, out m)) return new ValidationResult("Le format est incorrect");
            if (!int.TryParse(day, out d)) return new ValidationResult("Le format est incorrect");
            DateTime dt = new DateTime(1900 + y, m, d);
            DateTime bd = (DateTime)context.ObjectType.GetProperty(_fieldName).GetValue(context.ObjectInstance);
            if (dt != bd) return new ValidationResult("Dates ne correspondent pas.");
            return ValidationResult.Success;
        }
    }
}
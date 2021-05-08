using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _05AspMvc.Tools.Validation
{
    public class CustomValidationDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is null) return false;
            DateTime dt;
            if (!DateTime.TryParse(value.ToString(), out dt)) return false;
            if ((DateTime.Now.Year - dt.Year) < 16) return false;
            return true;
        }
    }
}
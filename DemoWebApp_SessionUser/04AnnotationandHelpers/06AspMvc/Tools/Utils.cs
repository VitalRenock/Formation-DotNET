using _05AspMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _05AspMvc.Tools
{
    public class Utils
    {
        public static UserAsp SessionUser { 
            get
            {
                return (UserAsp)HttpContext.Current.Session["user"];
            }
            set
            {
                HttpContext.Current.Session["user"] = value;
            }
        
        }
    }
}
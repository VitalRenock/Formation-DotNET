using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using _04ModelClient.Data;
using _05AspMvc.Areas.Admin.Data;
using _05AspMvc.Models;
using _05AspMvc.Models.Views;

namespace _05AspMvc.Tools.Mappers
{
    public static class Mapper
    {
        #region User

        public static UserAsp ToMvc(this UserClient user)
        {
            return new UserAsp(user.Id, user.Mail, user.Password, user.LastName, user.FirstName, user.BirthDate, user.RegNational, user.Bio);
        }
        //public static AspUserRight ToUserRight(this UserClient user)
		//{
        //    return new AspUserRight(user.Id, user.Mail, user.LastName, user.FirstName);
		//}

        public static UserClient ToClient(this UserAsp user)
        {
            return new UserClient(user.Id, user.Mail, user.Password, user.LastName, user.FirstName, user.BirthDate, user.RegNational, user.Bio);
        }

        public static UserClient ToClient(this UserAspRegister user)
        {
            return new UserClient(user.Id, user.Mail, user.Password, user.LastName, user.FirstName, user.BirthDate, user.RegNational, user.Bio);
        }

        #endregion
    }
}
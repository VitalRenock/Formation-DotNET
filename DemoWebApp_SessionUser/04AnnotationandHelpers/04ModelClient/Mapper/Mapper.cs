using _03ModelGlobal.Data;
using _04ModelClient.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04ModelClient.Mapper
{
    internal static class Mapper
    {
        #region user
        internal static UserGlobal ToGlobal(this UserClient user)
        {
            return new UserGlobal()
            {
                Id = user.Id,
                Mail = user.Mail,
                Password = user.Password,
                LastName = user.LastName,
                FirstName = user.FirstName,
                BirthDate = user.BirthDate,
                RegNational = user.RegNational,
                Bio = user.Bio
            };
        }

        internal static UserClient ToClient(this UserGlobal user)
        {
            return new UserClient(user.Id, user.Mail, user.Password, user.LastName, user.FirstName, user.BirthDate, user.RegNational, user.Bio);
        }
        #endregion
    }
}

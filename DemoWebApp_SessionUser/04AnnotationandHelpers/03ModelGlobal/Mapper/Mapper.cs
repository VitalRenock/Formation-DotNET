using _03ModelGlobal.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03ModelGlobal.Mapper
{
    internal static class Mapper
    {
        internal static UserGlobal ToGlobal(this IDataRecord reader)
        {
            return new UserGlobal()
            {
                Id = (int)reader[nameof(UserGlobal.Id)],
                Mail = (string)reader[nameof(UserGlobal.Mail)],
                Password = (string)reader[nameof(UserGlobal.Password)],
                LastName = (string)reader[nameof(UserGlobal.LastName)],
                FirstName = (string)reader[nameof(UserGlobal.FirstName)],
                BirthDate = (DateTime)reader[nameof(UserGlobal.BirthDate)],
                RegNational = (string)reader[nameof(UserGlobal.RegNational)],
                Bio = (reader[nameof(UserGlobal.Bio)] == DBNull.Value) ? null : (string)reader[nameof(UserGlobal.Bio)]
            };
        }
    }
}

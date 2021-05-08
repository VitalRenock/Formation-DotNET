using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModelGlobal.Data;

namespace ModelGlobal.Mapper
{
	/// <summary>
	/// Mapper entre un 'IDataRecord' et 'UserGlobal'.
	/// </summary>
	internal static class IDataRecordExtensions
	{
		#region User Extension
		
		internal static UserGlobal ToUserGlobal(this IDataRecord dataRecord)
		{
			return new UserGlobal(
				(int)dataRecord["Id"],
				(string)dataRecord["Email"],
				(string)dataRecord["Password"],
				(string)dataRecord["Lastname"],
				(string)dataRecord["Firstname"],
				(DateTime)dataRecord["Birthdate"],
				(string)dataRecord["NationalRegister"],
				(string)dataRecord["Biography"]
				);
		}

		#endregion
	}
}
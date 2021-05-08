using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModelGlobal.Data;

namespace ModelGlobal.Mapper
{
	public static class IDataRecordExtension
	{
		/// <summary>
		/// Transforme un 'DataRecord' en 'GameGlobal'
		/// </summary>
		/// <param name="dataRecord"></param>
		/// <returns></returns>
		public static GameGlobal ToGameGlobal(this IDataRecord dataRecord)
		{
			return new GameGlobal()
			{
				Id = (int)dataRecord["Id"],
				Title = (string)dataRecord["Title"],
				Editor = (string)dataRecord["Editor"],
			};
		}
	}
}

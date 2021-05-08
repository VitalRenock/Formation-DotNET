using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelGlobal.Models
{
	public class MovieGlobal : MovieBase
	{
		#region Constructors
		
		public MovieGlobal()
		{
		}

		public MovieGlobal(string title, string director, DateTime releaseDate, int budget, string actorMain)
			: base(title, director, releaseDate, budget, actorMain)
		{
		}

		public MovieGlobal(int id, string title, string director, DateTime releaseDate, int budget, string actorMain)
			: base(id, title, director, releaseDate, budget, actorMain)
		{
		}

		#endregion
	}
}
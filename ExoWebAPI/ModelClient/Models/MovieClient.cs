using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModelGlobal.Models;

namespace ModelClient.Models
{
	public class MovieClient : MovieBase
	{
		#region Constructors
		
		public MovieClient()
		{
		}

		public MovieClient(string title, string director, DateTime releaseDate, int budget, string actorMain)
			: base(title, director, releaseDate, budget, actorMain)
		{
		}

		public MovieClient(int id, string title, string director, DateTime releaseDate, int budget, string actorMain)
			: base(id, title, director, releaseDate, budget, actorMain)
		{
		}

		#endregion
	}
}

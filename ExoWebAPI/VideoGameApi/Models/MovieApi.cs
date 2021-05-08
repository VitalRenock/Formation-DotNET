using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ModelGlobal.Models;

namespace VideoGameApi.Models
{
	public class MovieApi : MovieBase
	{
		#region Constructors
		
		public MovieApi()
		{
		}

		public MovieApi(string title, string director, DateTime releaseDate, int budget, string actorMain)
			: base(title, director, releaseDate, budget, actorMain)
		{
		}

		public MovieApi(int id, string title, string director, DateTime releaseDate, int budget, string actorMain)
			: base(id, title, director, releaseDate, budget, actorMain)
		{
		}

		#endregion
	}
}
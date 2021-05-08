using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelGlobal.Models
{
	public abstract class MovieBase
	{
		#region Properties
		
		public int Id { get; set; }
		public string Title { get; set; }
		public string Director { get; set; }
		public DateTime ReleaseDate { get; set; }
		public int Budget { get; set; }
		public string ActorMain { get; set; }

		#endregion

		#region Constructors

		protected MovieBase()
		{
		}

		protected MovieBase(string title, string director, DateTime releaseDate, int budget, string actorMain)
		{
			Title = title;
			Director = director;
			ReleaseDate = releaseDate;
			Budget = budget;
			ActorMain = actorMain;
		}

		protected MovieBase(int id, string title, string director, DateTime releaseDate, int budget, string actorMain)
		{
			Id = id;
			Title = title;
			Director = director;
			ReleaseDate = releaseDate;
			Budget = budget;
			ActorMain = actorMain;
		}

		#endregion
	}
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModelGlobal.Models;

namespace ModelGlobal.Mapper
{
	internal static class Mapper
	{
		internal static VideoGameGlobal ToVideoGame(this IDataRecord dataRecord)
		{
			return new VideoGameGlobal
			{
				Id = (int)dataRecord[nameof(VideoGameGlobal.Id)],
				Title = (string)dataRecord[nameof(VideoGameGlobal.Title)],
				Cote = (int)dataRecord[nameof(VideoGameGlobal.Cote)],
				Editor = (string)dataRecord[nameof(VideoGameGlobal.Editor)],
				TypeGame = (string)dataRecord[nameof(VideoGameGlobal.TypeGame)],
				NbJoueurs = (int)dataRecord[nameof(VideoGameGlobal.NbJoueurs)],
				Plateform = (string)dataRecord[nameof(VideoGameGlobal.Plateform)]
			};
		}

		internal static MovieGlobal ToMovie(this IDataRecord dataRecord)
		{
			return new MovieGlobal
			{
				Id = (int)dataRecord[nameof(MovieGlobal.Id)],
				Title = (string)dataRecord[nameof(MovieGlobal.Title)],
				Director = (string)dataRecord[nameof(MovieGlobal.Director)],
				ReleaseDate = (DateTime)dataRecord[nameof(MovieGlobal.ReleaseDate)],
				Budget = (int)dataRecord[nameof(MovieGlobal.Budget)],
				ActorMain = (string)dataRecord[nameof(MovieGlobal.ActorMain)]
			};
		}
	}
}

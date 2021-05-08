using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModelClient.Models;
using ModelGlobal.Models;

namespace ModelClient.Mapper
{
    internal static class Mapper
    {
		#region VideoGame Mapper
		
		internal static VideoGameGlobal ToGlobal(this VideoGameClient game)
		{
			return new VideoGameGlobal()
			{
				Id = game.Id,
				Title = game.Title,
				Cote = game.Cote,
				Editor = game.Editor,
				TypeGame = game.TypeGame,
				NbJoueurs = game.NbJoueurs,
				Plateform = game.Plateform
			};
		}

		internal static VideoGameClient ToClient(this VideoGameGlobal game)
		{
			return new VideoGameClient()
			{
				Id = game.Id,
				Title = game.Title,
				Cote = game.Cote,
				Editor = game.Editor,
				TypeGame = game.TypeGame,
				NbJoueurs = game.NbJoueurs,
				Plateform = game.Plateform
			};
		}

		#endregion

		#region Movie Mapper

		internal static MovieClient ToClient(this MovieGlobal movie)
		{
			return new MovieClient()
			{
				Id = movie.Id,
				Title = movie.Title,
				Director = movie.Director,
				ReleaseDate = movie.ReleaseDate,
				Budget = movie.Budget,
				ActorMain = movie.ActorMain
			};
		}

		internal static MovieGlobal ToGlobal(this MovieClient movie)
		{
			return new MovieGlobal()
			{
				Id = movie.Id,
				Title = movie.Title,
				Director = movie.Director,
				ReleaseDate = movie.ReleaseDate,
				Budget = movie.Budget,
				ActorMain = movie.ActorMain
			};
		}

		#endregion
	}
}
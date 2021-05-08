using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ModelClient.Models;
using VideoGameApi.Models;

namespace VideoGameApi.Mapper
{
	public static class Mapper
	{
		#region VideoGame Mapper
		
		public static VideoGameFinal ToFinal(this VideoGameClient game) => new VideoGameFinal(game.Id, game.Title, game.Cote, game.Editor, game.TypeGame, game.NbJoueurs, game.Plateform);

		public static VideoGameClient ToClient(this VideoGameFinal game) => new VideoGameClient(game.Id, game.Title, game.Cote, game.Editor, game.TypeGame, game.NbJoueurs, game.Plateform);

		#endregion

		#region Movie Mapper

		public static MovieApi ToApi(this MovieClient movie) => new MovieApi(movie.Id, movie.Title, movie.Director, movie.ReleaseDate, movie.Budget, movie.ActorMain);

		public static MovieClient ToClient(this MovieApi movie) => new MovieClient(movie.Id, movie.Title, movie.Director, movie.ReleaseDate, movie.Budget, movie.ActorMain);

		#endregion
	}
}
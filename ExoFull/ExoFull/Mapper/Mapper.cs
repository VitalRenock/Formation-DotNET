using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

using ExoFull.Models;
using ModelClient.Data;

namespace ExoFull.Mapper
{
	public static class Mapper
	{
		///// <summary>
		///// Convertit un 'IDataRecord' en 'Game'
		///// </summary>
		///// <param name="dataRecord"></param>
		///// <returns></returns>
		//public static Game ToGame(this IDataRecord dataRecord)
		//{
		//	Game game = new Game((string)dataRecord["Title"], (string)dataRecord["Editor"]);
		//	return game;
		//}

		/// <summary>
		/// Convertit un 'IDataRecord' en 'Game'
		/// </summary>
		/// <param name="dataRecord"></param>
		/// <returns></returns>
		public static Game ToGame(this GameClient gameClient)
		{
			Game game = new Game(gameClient.Id, gameClient.Title, gameClient.Editor);
			return game;
		}

		public static GameClient ToClient(this Game game)
		{
			return new GameClient(game.Id, game.Title, game.Editor);
		}

	}
}
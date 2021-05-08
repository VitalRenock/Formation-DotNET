using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using G = ModelGlobal.Data;
using ModelClient.Data;

namespace ModelClient.Mapper
{
	internal static class Mapper
	{
		#region Game Mapper
		
		internal static G.GameGlobal ToGlobal(this GameClient game)
		{
			return new G.GameGlobal()
			{
				Id = game.Id,
				Title = game.Title,
				Editor = game.Editor
			};
		}

		internal static GameClient ToClient(this G.GameGlobal game)
		{
			return new GameClient(game.Id, game.Title, game.Editor);
		}

		#endregion
	}
}

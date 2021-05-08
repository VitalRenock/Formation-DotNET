using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VitalTools.Pattern;
using ModelClient.Data;
using ModelGlobal.Services;
using ModelClient.Mapper;

namespace ModelClient.Services
{
	public class GameClientService : IGameRepo<GameClient>
	{
		private IGameRepo<GameGlobalService> globalService;

		public GameClientService()
		{
			//globalService = new GameGlobalService();
		}
		#region Public Methods

		public void Add(GameClient game)
		{
			//globalService.Add(game.ToGlobal());
		}

		public bool Delete(int id)
		{
			//globalService.Delete(id);

			return true;
		}

		public bool Edit(int id, GameClient game)
		{
			//globalService.Edit(id, game.ToGlobal())

			return true;
		}

		public IEnumerable<GameClient> GetAll()
		{
			//return globalService.GetAll().Select(g => g.ToClient());

			return IEnumerable<GameClient>()
		}

		public GameClient GetById(int id)
		{
			//return globalService.GetById(id)?.ToClient();

			return new GameClient();
		}

		#endregion
	}
}
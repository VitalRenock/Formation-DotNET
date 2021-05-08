using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModelClient.Models;
using ModelClient.Mapper;
using ModelGlobal.Models;
using ModelGlobal.Services;
using VitalTools.Pattern;

namespace ModelClient.Services
{
	public class VideoGameClientService : IRepository<VideoGameClient>
	{
		// Global Services
		private IRepository<VideoGameGlobal> _videoGameGlobalService;
		
		// Constructor
		public VideoGameClientService() => _videoGameGlobalService = new VideoGameGlobalService();

		#region CRUD Methods
		
		public IEnumerable<VideoGameClient> Get() => _videoGameGlobalService.Get().Select(vg => vg.ToClient());

		public VideoGameClient Get(int id) => _videoGameGlobalService.Get(id)?.ToClient();

		public int Add(VideoGameClient game) => _videoGameGlobalService.Add(game.ToGlobal());

		public bool Edit(int id, VideoGameClient game) => _videoGameGlobalService.Edit(id, game.ToGlobal());

		public bool Delete(int id) => _videoGameGlobalService.Delete(id);

		#endregion
	}
}

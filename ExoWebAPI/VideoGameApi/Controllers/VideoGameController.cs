using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

using VideoGameApi.Models;
using ModelClient.Services;
using VideoGameApi.Mapper;

namespace VideoGameApi.Controllers
{
	public class VideoGameController : ApiController
	{
		// Client Services
		VideoGameClientService videoGameClientService; 

		// Constructors
		public VideoGameController() => videoGameClientService = new VideoGameClientService();

		#region CRUD Methods
		
		public IEnumerable<VideoGameFinal> Get() => videoGameClientService.Get().Select(vg => vg.ToFinal());

		public VideoGameFinal Get(int id) => videoGameClientService.Get(id).ToFinal();

		public int Post([FromBody] VideoGameFinal game) => videoGameClientService.Add(game.ToClient());

		public bool Put(int id, [FromBody] VideoGameFinal game) => videoGameClientService.Edit(id, game.ToClient());

		public bool Delete(int id) => videoGameClientService.Delete(id);

		#endregion
	}
}
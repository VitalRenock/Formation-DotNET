using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using ModelClient.Services;
using VideoGameApi.Mapper;
using VideoGameApi.Models;

namespace VideoGameApi.Controllers
{
    public class MovieController : ApiController
    {
		// Client Services
        MovieClientService movieClientService; 

		// Constructors
		public MovieController() => movieClientService = new MovieClientService();

		#region CRUD Methods
		
		// GET: api/Movie
		public IEnumerable<MovieApi> Get() => movieClientService.Get().Select(m => m.ToApi());

		// GET: api/Movie/5
		public MovieApi Get(int id) => movieClientService.Get(id).ToApi();

		// POST: api/Movie
		public int Post([FromBody] MovieApi movie) => movieClientService.Add(movie.ToClient());

		// PUT: api/Movie/5
		public bool Put(int id, [FromBody] MovieApi movie) => movieClientService.Edit(id, movie.ToClient());

		// DELETE: api/Movie/5
		public bool Delete(int id) => movieClientService.Delete(id);

		#endregion
	}
}
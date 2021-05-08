using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModelClient.Models;
using ModelClient.Mapper;
using ModelGlobal.Services;
using VitalTools.Pattern;

namespace ModelClient.Services
{
	public class MovieClientService : IRepository<MovieClient>
	{
		// Cient Services
		MovieGlobalService movieGlobalService; 

		// Constructors
		public MovieClientService() => movieGlobalService = new MovieGlobalService();

		#region CRUD Methods

		public IEnumerable<MovieClient> Get() => movieGlobalService.Get().Select(m => m.ToClient());

		public MovieClient Get(int id) => movieGlobalService.Get(id).ToClient();

		public int Add(MovieClient item) => movieGlobalService.Add(item.ToGlobal());

		public bool Edit(int id, MovieClient item) => movieGlobalService.Edit(id, item.ToGlobal());

		public bool Delete(int id) => movieGlobalService.Delete(id);

		#endregion
	}
}

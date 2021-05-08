using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoAPI_Console
{
	class Program
	{
		static void Main(string[] args)
		{
			ApiRequester requester = new ApiRequester("http://localhost:61515/api/");
			List<MovieConso> movies = requester.Get<List<MovieConso>>("Movie");

			foreach (MovieConso movie in movies)
			{
				Console.WriteLine(movie.Title);
			}


			Console.ReadLine();
		}
	}
}

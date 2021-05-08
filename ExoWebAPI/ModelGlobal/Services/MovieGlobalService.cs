using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModelGlobal.Models;
using ModelGlobal.Mapper;
using VitalTools.Database;
using VitalTools.Database.Formation;
using VitalTools.Database.SmartCommand;
using VitalTools.Pattern;
using VitalTools.Database.RequestFactory;

namespace ModelGlobal.Services
{
	public class MovieGlobalService : IRepository<MovieGlobal>
	{
		#region Properties
		
		Connection connection;
		ConnectionFormation connectionFormation; 

		#endregion

		#region Constructors

		public MovieGlobalService()
		{
			connection = new Connection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FullDB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
			connectionFormation = new ConnectionFormation(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FullDB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
		}

		#endregion

		#region CRUD Methods
		
		public IEnumerable<MovieGlobal> Get()
		{
			SelectAllCmd selectAllCmd = new SelectAllCmd("Movie");
			return connection.ExecuteReader(selectAllCmd, m => m.ToMovie());
		}

		public MovieGlobal Get(int id)
		{
			CommandFormation command = new CommandFormation("SELECT * FROM Movie WHERE Id = @id");
			command.AddParameter("id", id);
			return connectionFormation.ExecuteReader(command, m => m.ToMovie()).SingleOrDefault();
		}

		public int Add(MovieGlobal movie)
		{
			CommandFormation command = new CommandFormation("INSERT INTO Movie (Title, Director, ReleaseDate, Budget, ActorMain) OUTPUT INSERTED.Id VALUES (@title, @director, @releaseDate, @budget, @actorMain);");
			command.AddParameter("title", movie.Title);
			command.AddParameter("director", movie.Director);
			command.AddParameter("releaseDate", movie.ReleaseDate);
			command.AddParameter("budget", movie.Budget);
			command.AddParameter("actorMain", movie.ActorMain);

			return (int)connectionFormation.ExecuteScalar(command);
		}

		public bool Edit(int id, MovieGlobal movie)
		{
			CommandFormation command = new CommandFormation("UPDATE Movie SET Title = @title, Director = @director, ReleaseDate = @releaseDate, Budget = @budget, ActorMain = @actorMain WHERE Id = @id;");
			command.AddParameter("id", id);
			command.AddParameter("title", movie.Title);
			command.AddParameter("director", movie.Director);
			command.AddParameter("releaseDate", movie.ReleaseDate);
			command.AddParameter("budget", movie.Budget);
			command.AddParameter("actorMain", movie.ActorMain);

			return connectionFormation.ExecuteNonQuery(command) == 1;
		}

		public bool Delete(int id)
		{
			CommandFormation command = new CommandFormation("DELETE FROM Movie WHERE Id = @id;");
			command.AddParameter("id", id);

			return connectionFormation.ExecuteNonQuery(command) == 1;
		}

		#endregion
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModelGlobal.Data;
using ModelGlobal.Mapper;
using VitalTools.Database;
using VitalTools.Pattern;

namespace ModelGlobal.Services
{
	public class GameGlobalService : IGameRepo<GameGlobal>
	{
		#region Properties
		
		private Connection connection;
		private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FullDB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

		#endregion

		#region Constructor

		public GameGlobalService()
		{
			connection = new Connection(connectionString);
		}

		#endregion

		public void Add(GameGlobal game)
		{
			Command command = new Command("INSERT INTO Game (Title, Editor) VALUES (@title, @editor);");
			command.AddParameter("title", game.Title);
			command.AddParameter("editor", game.Editor);
		}

		public bool Delete(int id)
		{
			Command command = new Command("DELETE FROM Game WHERE id = @id");
			command.AddParameter("id", id);

			return true;
			//return connection.ExecuteNonQuery(command);
		}

		public bool Edit(int id, GameGlobal game)
		{
			Command command = new Command("UPDATE Game Set title = @title, editor = @editor WHERE id = @id");
			command.AddParameter("id", game.Id);
			command.AddParameter("title", game.Title);
			command.AddParameter("editor", game.Editor);

			return connection.ExecuteNonQuery(command) == 1;
		}

		public IEnumerable<GameGlobal> GetAll()
		{
			Command command = new Command("SELECT * FROM Game");
			return connection.ExecuteReader(command, g => g.ToGameGlobal());
		}

		public GameGlobal GetById(int id)
		{
			Command command = new Command("SELECT * FROM Game WHERE Id = @id");
			command.AddParameter("id", id);

			return connection.ExecuteReader(command, g => g.ToGameGlobal()).SingleOrDefault();
		}
	}
}

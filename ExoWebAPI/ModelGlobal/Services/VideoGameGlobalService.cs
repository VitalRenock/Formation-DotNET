using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModelGlobal.Models;
using ModelGlobal.Mapper;
using VitalTools.Database.Formation;
using VitalTools.Pattern;

namespace ModelGlobal.Services
{
	public class VideoGameGlobalService : IRepository<VideoGameGlobal>
	{
		// Connection Database
		private ConnectionFormation _connection;
		private string connectionStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FullDB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
		
		// Constructors
		public VideoGameGlobalService() => _connection = new ConnectionFormation(connectionStr);

		#region CRUD Methods
		
		public IEnumerable<VideoGameGlobal> Get()
		{
			CommandFormation command = new CommandFormation("Select * FROM Game;");
			return _connection.ExecuteReader(command, vg => vg.ToVideoGame());
		}

		public VideoGameGlobal Get(int id)
		{
			CommandFormation command = new CommandFormation("SELECT * FROM Game WHERE Id = @id;");
			command.AddParameter("id", id);
			//le reader me renvoi un tableau même pour une seul valeur, je lui précise qu'il ne me faut que le premier résultat
			return _connection.ExecuteReader(command, vg => vg.ToVideoGame()).SingleOrDefault();
		}

		public int Add(VideoGameGlobal game)
		{
			CommandFormation command = new CommandFormation("INSERT INTO Game (Title, Cote, Editor, TypeGame, NbJoueurs, Plateform) OUTPUT Inserted.Id VALUES (@title, @cote, @editor, @typeGame, @nbJoueurs, @plateform);");
			command.AddParameter("title", game.Title);
			command.AddParameter("cote", game.Cote);
			command.AddParameter("editor", game.Editor);
			command.AddParameter("typeGame", game.TypeGame);
			command.AddParameter("nbJoueurs", game.NbJoueurs);
			command.AddParameter("plateform", game.Plateform);
			return (int)_connection.ExecuteScalar(command);
		}

		public bool Edit(int id, VideoGameGlobal game)
		{
			CommandFormation command = new CommandFormation("UPDATE Game SET Title = @title, Cote = @cote, Editor = @editor, TypeGame = @typeGame, NbJoueurs = @nbJoueurs, Plateform = @plateform WHERE Id = @id;");
			command.AddParameter("title", game.Title);
			command.AddParameter("cote", game.Cote);
			command.AddParameter("editor", game.Editor);
			command.AddParameter("typeGame", game.TypeGame);
			command.AddParameter("nbJoueurs", game.NbJoueurs);
			command.AddParameter("plateform", game.Plateform);
			command.AddParameter("id", id);

			// Quoi qu'il arrive le resultat sera le nbr de ligne modifié
			// pour renvoyer un boolean, je fais un test == 1
			return _connection.ExecuteNonQuery(command) == 1;
		}

		public bool Delete(int id)
		{
			CommandFormation command = new CommandFormation("DELETE FROM Game WHERE Id = @id;");
			command.AddParameter("id", id);
			return _connection.ExecuteNonQuery(command) == 1;
		}

		#endregion
	}
}
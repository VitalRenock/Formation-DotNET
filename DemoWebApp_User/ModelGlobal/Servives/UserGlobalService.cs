using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModelGlobal.Data;
using ModelGlobal.Mapper;
using VitalTools.Database;
using VitalTools.Pattern;

namespace ModelGlobal.Servives
{
	public class UserGlobalService : IRepository<UserGlobal>
	{
		#region Properties
		
		private Connection connection;
		private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ExoASPUserDB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
		
		#endregion

		#region Constructors

		public UserGlobalService()
		{
			connection = new Connection(connectionString);
		}

		#endregion

		#region Public Methods

		public IEnumerable<UserGlobal> GetAll()
		{
			Command command = new Command("SELECT * FROM [User]");

			return connection.ExecuteReader(command, u => u.ToUserGlobal());
		}

		public UserGlobal GetById(int id)
		{
			Command command = new Command("SELECT * FROM [User] WHERE Id=@id");
			command.AddParameter("id", id);

			return connection.ExecuteReader(command, u => u.ToUserGlobal()).SingleOrDefault();
		}

		public void Add(UserGlobal user)
		{
			Command command = new Command("INSERT INTO [User] (Email, Password, Lastname, Firstname, Birthdate, NationalRegister, Biography) VALUES (@email, @password, @lastname, @firstname, @birthdate, @nationalRegister, @biography);");
			command.AddParameter("email", user.Email);
			command.AddParameter("password", user.Password);
			command.AddParameter("lastname", user.Lastname);
			command.AddParameter("firstname", user.Firstname);
			command.AddParameter("birthdate", user.Birthdate);
			command.AddParameter("nationalRegister", user.NationalRegister);
			command.AddParameter("biography", user.Biography);

			connection.ExecuteNonQuery(command);
		}

		public bool Edit(int id, UserGlobal user)
		{
			Command command = new Command("UPDATE [User] Set Email=@email, Password=@password, Lastname=@lastname, Firstname=@firstname, Birthdate=@birthdate, NationalRegister=@nationalRegister, Biography=@biography WHERE Id=@id;");
			command.AddParameter("id", user.Id);
			command.AddParameter("email", user.Email);
			command.AddParameter("password", user.Password);
			command.AddParameter("lastname", user.Lastname);
			command.AddParameter("firstname", user.Firstname);
			command.AddParameter("birthdate", user.Birthdate);
			command.AddParameter("nationalRegister", user.NationalRegister);
			command.AddParameter("biography", user.Biography);

			return connection.ExecuteNonQuery(command) == 1;
		}

		public bool Delete(int id)
		{
			Command command = new Command("Delete FROM [User] WHERE Id=@id");
			command.AddParameter("id", id);

			return connection.ExecuteNonQuery(command) == 1;
		}

		#endregion
	}
}

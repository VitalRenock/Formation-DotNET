using _01ConnectionTool;
using _02IRepository;
using _03ModelGlobal.Data;
using _03ModelGlobal.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03ModelGlobal.Services
{
    public class UserGlobalService : IUserRepo<UserGlobal>
    {
        private Connection _connection;
        private string _conStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBUser;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public UserGlobalService()
        {
            _connection = new Connection(_conStr);
        }





        public IEnumerable<UserGlobal> GetAll()
        {
            Command command = new Command("SP_AspUser_GetAll", true);
            return _connection.ExecuteReader(command, u => u.ToGlobal());
        }

        public UserGlobal GetbyId(int id)
        {
            Command command = new Command("SP_AspUser_GetById", true);
            command.AddParameter("id", id);
            return _connection.ExecuteReader(command, u => u.ToGlobal()).SingleOrDefault();
        }
        
        public int Add(UserGlobal user)
        {
            Command command = new Command("SP_AspUser_Insert", true);
            command.AddParameter("mail", user.Mail);
            command.AddParameter("password", user.Password);
            command.AddParameter("lastname", user.LastName);
            command.AddParameter("firstname", user.FirstName);
            command.AddParameter("birthdate", user.BirthDate);
            command.AddParameter("regnational", user.RegNational);
            command.AddParameter("bio", user.Bio);
            return (int)_connection.ExecuteScalar(command);
        }

        public bool Edit(int id, UserGlobal user)
        {
            Command command = new Command("SP_AspUser_Update", true);
            command.AddParameter("id", id);
            command.AddParameter("password", user.Password);
            command.AddParameter("lastname", user.LastName);
            command.AddParameter("firstname", user.FirstName);
            command.AddParameter("birthdate", user.BirthDate);
            command.AddParameter("regnational", user.RegNational);
            command.AddParameter("bio", user.Bio);
            return _connection.ExecuteNonQuery(command) == 1;
        }

        public bool Delete(int id)
        {
            Command command = new Command("SP_AspUser_Delete", true);
            command.AddParameter("id", id);
            return _connection.ExecuteNonQuery(command) == 1;
        }

        public int? CheckPassword(string identifier, string password)
        {
            Command command = new Command("SP_AspUser_CheckPassword", true);
            command.AddParameter("identifier", identifier);
            command.AddParameter("password", password);
            return (int?)_connection.ExecuteScalar(command);
        }





		public bool HaveAdminRight(int id)
		{
            Command command = new Command("SP_AspUser_HaveAdminRight", true);
            command.AddParameter("userid", id);
            return ((int?)_connection.ExecuteScalar(command) is null) ? false : true;
        }

		public bool HaveDefaultRight(int id)
		{
            Command command = new Command("SP_AspUser_HaveDefaultRight", true);
            command.AddParameter("userid", id);
            return ((int?)_connection.ExecuteScalar(command) is null) ? false : true;
        }

		public void GrantAdmin(int id)
		{
            Command command = new Command("SP_UserRight_GrantAdmin", true);
            command.AddParameter("userid", id);
            _connection.ExecuteNonQuery(command);
		}

		public void GrantDefault(int id)
		{
            Command command = new Command("SP_UserRight_GrantDefault", true);
            command.AddParameter("userid", id);
            _connection.ExecuteNonQuery(command);
        }

		public void DenyAdmin(int id)
		{
            Command command = new Command("SP_UserRight_DenyAdmin", true);
            command.AddParameter("userid", id);
            _connection.ExecuteNonQuery(command);
        }

		public void DenyDefault(int id)
		{
            Command command = new Command("SP_UserRight_DenyDefault", true);
            command.AddParameter("userid", id);
            _connection.ExecuteNonQuery(command);
        }
	}
}

using Microsoft.Models.Entities;
using Microsoft.Models.Interfaces;
using Microsoft.Models.Mappers;
using System.Collections.Generic;
using System.Linq;
using Tools.Connections.Database;

namespace Microsoft.Models.Services
{
    public class PersonRepository : IPersonRepository<Person>
    {
        private readonly IConnection _connection;

        public PersonRepository(IConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Person> Get()
        {
            Command command = new Command("Select Top 100 BusinessEntityId, Title, LastName, FirstName From Person.Person;");

            return _connection.ExecuteReader(command, dr => dr.ToPerson());
        }

        public Person Get(int id)
        {
            Command command = new Command("Select BusinessEntityId, Title, LastName, FirstName From Person.Person Where BusinessEntityId = @Id;");
            command.AddParameter("Id", id);

            return _connection.ExecuteReader(command, dr => dr.ToPerson()).SingleOrDefault();
        }
    }
}

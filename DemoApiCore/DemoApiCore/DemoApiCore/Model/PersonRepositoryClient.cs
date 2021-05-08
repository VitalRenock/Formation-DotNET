using Microsoft.Models.Entities;
using Microsoft.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApiCore.Model
{
    public class PersonRepositoryClient
    {
        private readonly IPersonRepository<Person> _repository;

        public PersonRepositoryClient(IPersonRepository<Person> repository)
        {
            _repository = repository;
        }

        public IEnumerable<PersonClient> Get()
        {
            return _repository.Get().Select(p => new PersonClient(p.BusinessEntityId, p.Title, p.LastName, p.FirstName));
        }

        public PersonClient Get(int id)
        {
            Person person = _repository.Get(id);
            if (person is null)
                return null;

            return new PersonClient(person.BusinessEntityId, person.Title, person.LastName, person.FirstName);
        }
    }
}

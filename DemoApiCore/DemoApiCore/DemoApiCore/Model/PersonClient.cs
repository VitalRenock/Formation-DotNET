using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace DemoApiCore.Model
{
    [DataContract]
    public class PersonClient
    {
        public PersonClient(int businessEntityId, string title, string lastName, string firstName)
        {
            BusinessEntityId = businessEntityId;
            Title = title;
            LastName = lastName;
            FirstName = firstName;
        }

        [DataMember]
        public int BusinessEntityId { get; private set; }
        [DataMember]
        public string Title { get; private set; }
        [DataMember]
        public string LastName { get; private set; }
        [DataMember]
        public string FirstName { get; private set; }
    }
}

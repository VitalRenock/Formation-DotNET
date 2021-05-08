using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04ModelClient.Data
{
    public class UserClient
    {
        public int Id { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
        public string RegNational { get; set; }
        public string Bio { get; set; }

        public UserClient()
        {
        }

        public UserClient(string mail, string password, string lastName, string firstName, DateTime birthDate, string regNational, string bio)
        {
            Mail = mail;
            Password = password;
            LastName = lastName;
            FirstName = firstName;
            BirthDate = birthDate;
            RegNational = regNational;
            Bio = bio;
        }

        public UserClient(int id, string mail, string password, string lastName, string firstName, DateTime birthDate, string regNational, string bio)
        {
            Id = id;
            Mail = mail;
            Password = password;
            LastName = lastName;
            FirstName = firstName;
            BirthDate = birthDate;
            RegNational = regNational;
            Bio = bio;
        }
    }
}

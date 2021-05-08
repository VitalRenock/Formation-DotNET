using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfFirstApp.DemoModels
{
	class Person
	{
		public Person(string firstname, string lastname)
		{
			Firstname = firstname;
			Lastname = lastname;
		}

		public string Firstname { get; set; }
		public string Lastname { get; set; }
	}
}

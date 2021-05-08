using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfFirstApp.DemoModels;

namespace WpfFirstApp.DemoViewModels
{
	// Séparation entre la vue et le model.
	// Me permet de décider avec les getter et setter ce que je veux afficher de l'objet protégé.
	class PersonViewModel : ViewModelBase<Person>
	{
		public PersonViewModel(Person person) : base(person) { }

		public string Firstname { get { return Entity.Firstname; }  }
		public string Lastname { get { return Entity.Lastname; } }
	}
}

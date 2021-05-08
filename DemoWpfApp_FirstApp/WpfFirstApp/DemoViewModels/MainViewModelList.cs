using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfFirstApp.DemoModels;
using WpfFirstApp.DemoTools.DemoCommand;

namespace WpfFirstApp.DemoViewModels
{
	// Je veux utiliser une collection qui charge mes élements
	// On est obliger d'utiliser une 'ObservableCollection' qui permet de notifier la vue des changements.
	class MainViewModelList : ViewModelBase
	{
		private ObservableCollection<PersonViewModel> _People;
		public ObservableCollection<PersonViewModel> People { get { return _People;  } }


		public MainViewModelList()
		{
			_People = new ObservableCollection<PersonViewModel>();
			_People.Add(new PersonViewModel(new Person("Donald", "Duck")));
			_People.Add(new PersonViewModel(new Person("Daisy", "Duck")));
		}

		private RelayCommand _AddPersonCommand;
		public RelayCommand AddPersonCommand
		{
			get { return _AddPersonCommand ?? (_AddPersonCommand = new RelayCommand(AddPerson)); }
		}

		private void AddPerson()
		{
			Person zaza = new Person("Zaza", "Vanderquack");

			PersonViewModel warpper = new PersonViewModel(zaza);

			// Ajout de l'objet warppé. Event se déclenche
			_People.Add(warpper);
		}
	}
}

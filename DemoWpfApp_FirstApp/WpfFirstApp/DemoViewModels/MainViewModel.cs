using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfFirstApp.DemoTools.DemoCommand;

namespace WpfFirstApp.ViewModels
{
	class MainViewModel :INotifyPropertyChanged
	{

		private int _Counter;
		public int Counter
		{
			get { return _Counter; }
			set {
					_Counter = value;

					// Signale à la vue de mettre à jour la valeur.
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Counter)));

					// Signal à la vue de vérifier si la commande peut-être executé
					DownCommand.RaiseCanExecuteChanged();
				}
		}


		private RelayCommand _UpCommand;
		public RelayCommand UpCommand
		{
			// Exemple d'écriture 1
			get
			{
				if (_UpCommand is null)
					_UpCommand = new RelayCommand(ActionUp);
				return _UpCommand;
			}
		}

		private RelayCommand _DownCommand;

		public event PropertyChangedEventHandler PropertyChanged;

		public RelayCommand DownCommand
		{
			// Exemple d'écriture 2
			get { return _DownCommand ?? (_DownCommand = new RelayCommand(ActionDown, CanActionDown)); }
		}

		protected void ActionUp() => _Counter++;
		protected void ActionDown() => _Counter--;
		protected bool CanActionDown()
		{
			return Counter > 0;
		}

	}
}

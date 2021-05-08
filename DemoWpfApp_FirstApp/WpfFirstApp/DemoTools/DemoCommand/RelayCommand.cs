using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfFirstApp.DemoTools.DemoCommand
{
	class RelayCommand : ICommand
	{
		#region Delegates
		
		public event EventHandler CanExecuteChanged;
		// La méthode qui permet de notifier la vue qu'il faut vérifier le CanExecute
		public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);


		// 2 délégués pour gérer les interactions de commandes.
		private Action _Execute;
		private Func<bool> _CanExecute; 

		#endregion

		#region Constructors


		// (Démo d'appel de constructeur inversé)
		// 2 constructeurs pour créer une commande avec ou sans condition d'activation
		public RelayCommand(Action execute)
		{
			#region Protection contre les boutons ne fesant aucune action
			
			if (execute is null)
				throw new ArgumentNullException(nameof(execute));

			#endregion

			_Execute = execute;
			_CanExecute = null;
		}
		public RelayCommand(Action execute, Func<bool> canExecute) : this(execute)
		{
			_CanExecute = canExecute;
		}

		#endregion

		#region Méthode public

		/// <summary>
		/// Méthode appeler par le composant pour vérifier si celui-çi doit être activé.
		/// </summary>
		/// <param name="parameter"></param>
		/// <returns></returns>
		public bool CanExecute(object parameter)
		{
			return this._CanExecute?.Invoke() ?? true;
		}

		/// <summary>
		/// Méthode appeler par le composant lors de l'activation de la commance.
		/// </summary>
		/// <param name="parameter"></param>
		public void Execute(object parameter)
		{
			this._Execute.Invoke();
		}

		#endregion
	}
}

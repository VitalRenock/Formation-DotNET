using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DemoListeCourse.Tools.Commands
{
	/// <summary>
	/// (? ToolBox Classe de base pour les commandes de la BusinessLayer)
	/// </summary>
	class RelayCommand : ICommand
	{
		#region Delegates
		
		public event EventHandler CanExecuteChanged;

		// 2 Délégués pour stocker les interactions de la commande
		private Action _Execute;
		private Func<bool> _CanExecute;

		#endregion

		#region Constructors

		/// <summary>
		/// Constructeur pour créer une commande sans condition d'activation.
		/// </summary>
		/// <param name="execute">Commande à executer</param>
		public RelayCommand(Action execute)
		{
			#region Si l'action à effectuer est 'null' on remonte une erreur.
			
			if (execute is null) throw new ArgumentNullException(nameof(execute));

			#endregion

			this._Execute = execute;
			this._CanExecute = null;
		}

		/// <summary>
		/// Constructeur pour créer une commande avec condition d'activation
		/// </summary>
		/// <param name="execute">Commande à executer</param>
		/// <param name="canExecute">Condition d'activation</param>
		public RelayCommand(Action execute, Func<bool> canExecute) : this(execute)
		{
			this._CanExecute = canExecute;
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Méthode appelée par le composant pour vérifier si celui-ci doit être activé.
		/// </summary>
		/// <param name="parameter"></param>
		/// <returns></returns>
		public bool CanExecute(object parameter)
		{
			return this._CanExecute?.Invoke() ?? true;
		}

		/// <summary>
		/// Méthode appelée par le composant lors de l'activation de la commande.
		/// </summary>
		/// <param name="parameter"></param>
		public void Execute(object parameter) => this._Execute.Invoke();

		/// <summary>
		/// Méthode qui permet de notifier à la vue qu'il faut vérifier le délégué '_CanExecute'.
		/// </summary>
		public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

		#endregion
	}
}
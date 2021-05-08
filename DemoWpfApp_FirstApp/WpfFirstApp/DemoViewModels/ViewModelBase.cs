using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfFirstApp.DemoViewModels
{
	public abstract class ViewModelBase : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected void RaisePropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}

	//Créer une classe qui contiendra l'objet à protéger (Warper)
	// Ne laisse uniquement accessible dans ma classe ce que je souhaite.
	public abstract class ViewModelBase<TEntity> : ViewModelBase
	{
		private readonly TEntity _Entity;

		protected TEntity Entity
		{
			get { return _Entity; }
		}

		public ViewModelBase(TEntity entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException(nameof(entity));
			}
			this._Entity = entity;
		}
	}
}

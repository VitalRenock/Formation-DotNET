using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoListeCourse.Tools.ViewModels.ViewModelBase
{
	/// <summary>
	/// (? ToolBox Classe de base pour les classes passerelles de la Business Layer)
	/// </summary>
	public abstract class ViewModelBase : INotifyPropertyChanged
	{
		#region Delegates
		
		public event PropertyChangedEventHandler PropertyChanged;

		#endregion

		#region Protected Methods
		
		protected void RaisePropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

		#endregion
	}


	/// <summary>
	/// (? ToolBox Classe de base pour les classes passerelles de la Business Layer)
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	public abstract class ViewModelBase<TEntity> : ViewModelBase
	{
		#region Properties
		
		private readonly TEntity _Entity;
		protected TEntity Entity
		{
			get { return _Entity; }
		}

		#endregion

		#region Constructors
		
		public ViewModelBase(TEntity entity)
		{
			if (entity == null) throw new ArgumentNullException(nameof(entity));

			this._Entity = entity;
		}

		#endregion
	}
}

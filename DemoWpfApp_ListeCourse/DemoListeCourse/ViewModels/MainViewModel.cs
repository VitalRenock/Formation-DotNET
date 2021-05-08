using DemoListeCourse.Models;
using DemoListeCourse.Tools.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoListeCourse.ViewModels
{
	/// <summary>
	/// (? Classe pour la "Business Layer")
	/// </summary>
	class MainViewModel
	{
		#region Properties
		
		// List of product items
		private ObservableCollection<ProductItemViewModel> _shoppingList;
		public ObservableCollection<ProductItemViewModel> ShoppingList { get { return _shoppingList; } }

		// Commandes
		private RelayCommand _addProductItemCommand;
		public RelayCommand AddProductItemCommand
		{
			get { return _addProductItemCommand ?? (_addProductItemCommand = new RelayCommand(AddProductItem("",1,1))); }
		}

		#endregion

		#region Constructors

		public MainViewModel()
		{
			_shoppingList = new ObservableCollection<ProductItemViewModel>();

			#region Ajout par défaut de 2 produits (faculatif)

			_shoppingList.Add(new ProductItemViewModel(new ProductItem("Tomate", 3, 3)));
			_shoppingList.Add(new ProductItemViewModel(new ProductItem("Poivron", 5, 5)));

			#endregion
		}

		#endregion

		#region Business Methods

		/// <summary>
		/// Add product to 'ShoppingList'.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="price"></param>
		//private void AddProductItem()
		//{
		//	ProductItem newProduct = new ProductItem("VariableAPasser", 10, 10);

		//	// On encapsule l'objet à manipuler dans une classe passerelle (Warpper = Emballage)
		//	ProductItemViewModel warpper = new ProductItemViewModel(newProduct);

		//	_shoppingList.Add(warpper);
		//}

		// TO DO: Trouver un moyen de créer une commande qui autorise des paramètres? ...
		private bool AddProductItem(string name, int quantity, int price)
		{
			ProductItem newProduct = new ProductItem(name, quantity, price);

			// On encapsule l'objet à manipuler dans une classe passerelle (Warpper = Emballage)
			ProductItemViewModel warpper = new ProductItemViewModel(newProduct);

			_shoppingList.Add(warpper);

			return true;
		}

		#endregion
	}
}
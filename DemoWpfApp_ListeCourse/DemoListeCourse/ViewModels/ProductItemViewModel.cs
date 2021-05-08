using DemoListeCourse.Models;
using DemoListeCourse.Tools.ViewModels.ViewModelBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoListeCourse.ViewModels
{
	/// <summary>
	/// (? Classe passerelle entre la vue et les données.
	/// Retourne la valeur des propriétés que l'on expose de l'objet encapsulé.)
	/// </summary>
	class ProductItemViewModel : ViewModelBase<ProductItem>
	{
		#region Properties
		
		public string ProductName { get { return Entity.Name; } }
		public int ProductQuantity { get { return Entity.Quantity; } }
		public int ProductPrice { get { return Entity.Price; } } 

		#endregion

		#region Constructor

		public ProductItemViewModel(ProductItem productItem) : base(productItem) { }

		#endregion
	}
}

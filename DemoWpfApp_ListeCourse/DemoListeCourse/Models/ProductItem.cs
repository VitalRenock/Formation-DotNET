using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoListeCourse.Models
{
	/// <summary>
	/// (? Classe POCO pour dialoguer avec la base de données)
	/// </summary>
	class ProductItem
	{
		#region Properties
		
		public string Name { get; set; }
		public int Quantity { get; set; }
		public int Price { get; set; }

		#endregion

		#region Constructor
		
		public ProductItem(string name, int quantity, int price)
		{
			Name = name;
			Quantity = quantity;
			Price = price;
		}

		#endregion
	}
}

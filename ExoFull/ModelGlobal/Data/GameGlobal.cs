using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelGlobal.Data
{
	/// <summary>
	/// Classe de relation entre le modèle client et la DAL
	/// </summary>
	public class GameGlobal
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Editor { get; set; }
	}
}

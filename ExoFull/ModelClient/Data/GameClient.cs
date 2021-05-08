using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClient.Data
{
	/// <summary>
	/// Classe de relation entre l'application cliente et le modèle global
	/// </summary>
	public class GameClient
	{
		#region Properties
		
		public int Id { get; set; }
		public string Title { get; set; }
		public string Editor { get; set; }

		#endregion

		#region Constructors

		public GameClient()
		{
		}

		public GameClient(string title, string editor)
		{
			Title = title;
			Editor = editor;
		}

		public GameClient(int id, string title, string editor)
		{
			Id = id;
			Title = title;
			Editor = editor;
		} 

		#endregion
	}
}

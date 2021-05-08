using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClient.Models
{
	public class VideoGameClient
	{
		#region Properties
		
		public int Id { get; set; }
		public string Title { get; set; }
		public int Cote { get; set; }
		public string Editor { get; set; }
		public string TypeGame { get; set; }
		public int NbJoueurs { get; set; }
		public string Plateform { get; set; }

		#endregion

		#region Constructors

		public VideoGameClient()
		{
		}

		public VideoGameClient(string title, int cote, string editor, string typeGame, int nbJoueurs, string plateform)
		{
			Title = title;
			Cote = cote;
			Editor = editor;
			TypeGame = typeGame;
			NbJoueurs = nbJoueurs;
			Plateform = plateform;
		}

		public VideoGameClient(int id, string title, int cote, string editor, string typeGame, int nbJoueurs, string plateform)
		{
			Id = id;
			Title = title;
			Cote = cote;
			Editor = editor;
			TypeGame = typeGame;
			NbJoueurs = nbJoueurs;
			Plateform = plateform;
		}

		#endregion
	}
}
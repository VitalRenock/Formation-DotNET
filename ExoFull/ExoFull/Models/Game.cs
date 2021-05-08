using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExoFull.Models
{
	public class Game
	{
		#region Properties
		
		public int Id { get; set; }
		public string Title { get; set; }
		public string Editor { get; set; }

		#endregion

		#region Constructors

		public Game()
		{

		}

		public Game(string title, string editor)
		{
			Title = title;
			Editor = editor;
		}

		public Game(int id, string title, string editor)
		{
			Id = id;
			Title = title;
			Editor = editor;
		}

		#endregion
	}
}
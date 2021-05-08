using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelGlobal.Models
{
    public class VideoGameGlobal
    {
		public int Id { get; set; }
		public string Title { get; set; }
		public int Cote { get; set; }
		public string Editor { get; set; }
		public string TypeGame { get; set; }
		public int NbJoueurs { get; set; }
		public string Plateform { get; set; }
	}
}

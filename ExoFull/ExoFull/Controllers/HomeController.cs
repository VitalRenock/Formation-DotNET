using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using ExoFull.Mapper;
using VitalTools.Database;

namespace ExoFull.Controllers
{
	public class HomeController : Controller
	{
		static readonly string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False";
		Connection connection = new Connection(connectionString);

		public ActionResult Index()
		{
			Command command = new Command("SELECT * FROM Game");
			return View(connection.ExecuteReader(command, g => g.ToGame()));
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}

	public class GameController
	{
		private GameClientService gameClientService;

		public ActionResult Index()
		{

		}

		public ActionResult Details(int id)
		{
			return View(gameClientService)
		}

		public ActionResult Edit(int id)
		{
			return View(gameClientService.GetById(id).ToMVC)
		}

		public ActionResult Edit(int id, GameMVC game)
		{
			try
			{
				bool result = gameClientService.Edit(id, game)
			}
			catch (Exception)
			{

				throw;
			}
		}

		public ActionResult Delete(int id)
		{
			return View(gameClientService.GetById(id).ToMVC)
		}

		public ActionResult Delete(int id, GameMVC game)
		{
			try
			{
				bool result = gameClientService.Delete(id);


			}
			catch (Exception)
			{

				throw;
			}
		}


	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlastifaceMvc.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Message = "Welcome to ASP.NET MVC!";

			return View();
		}

		public ActionResult About()
		{
			return View();
		}

		public ActionResult Test()
		{
			return View();
		}

		public ActionResult CreateDialog()
		{
			return PartialView("_V1");
		}
	}
}

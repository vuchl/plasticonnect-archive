using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using BusinessLogic;

namespace PlastifaceMvc.Controllers
{
//	[Authorize]
	public class RfqController : Controller
	{
		public ActionResult Index()
		{
			var model = Operations.Requisitions.GetRfqDraft("jdoe");
//			var model = Operations.Requisitions.GetRfqDraft(User.Identity.Name);

			var test = Json(model.Items);
			ViewBag.DataSource = new HtmlString(new JavaScriptSerializer().Serialize(test.Data));

			return View(model);
		}

		public JsonResult GetNewItem(string type)
		{
			object newItem;

			switch (type)
			{
				case "PtoBag":
					newItem = CreateNewPtoBag();
					break;
				case "Sheeting":
					newItem = CreateNewSheeting();
					break;
				default:
					newItem = null;
					break;
			}
			return Json(newItem, JsonRequestBehavior.AllowGet);
		}

		private static object CreateNewPtoBag()
		{
			return new RfqItem
			{
			    Product = new PtoBag(),
			    Uom = Uom.M,
			    QuantityList = new List<int> {-1}
			};
		}

		private static object CreateNewSheeting()
		{
			return new RfqItem
			{
			    Product = new Sheeting(),
				Uom = Uom.Lbs,
				QuantityList = new List<int> { -1 }
			};
		}

		public ActionResult Test()
		{
			return PartialView("_PtoBagDialog");
		}

		[HttpPost]
		public ActionResult PostSomething(int i)
		{
			Debug.WriteLine(i);

			return Index();
		}
	}
}

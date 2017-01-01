using System;
using System.Data.Entity;
using Plasticore;

namespace ConsoleTester
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			//Triggers.BindWorkFlowTriggers();

			Database.SetInitializer(new PlasticoreContextInitializer());

			//Testing.TestCollection();
			WorkingWithRequisitions();

			Console.WriteLine("Presss any key");
			Console.ReadKey();
		}

		static void WorkingWithRequisitions()
		{
			var context = new PlasticoreContext();
			//			context.Database.Initialize(true);
			//			context.SaveChanges();


			var requisition = context.Requisitions.Find(1);
			Rfq rfq = null;

			if (requisition is Rfq)
				rfq = requisition as Rfq;

			if (rfq != null)
				PrintRfq(rfq);

			
		}

		static void PrintRfq(Rfq rfq)
		{
			Console.WriteLine("Request for a Quote");
			Console.WriteLine("===================");

			Console.WriteLine("      RFQ#: {0}", rfq.Id);
			Console.WriteLine("Issue Date: {0}", rfq.IssuedOn.Date);
			Console.WriteLine("  Deadline: {0}", rfq.Deadline);
			DrawLine();

			Console.WriteLine("Billing To:");
			Console.WriteLine("{0}{1}", "\t", rfq.CustomerName);
			PrintAddress(rfq.BillingAddress);

			Console.WriteLine("Items");
			Console.WriteLine("-----");

			PrintItems(rfq);

			DrawLine();
		}

		static void DrawLine()
		{
			Console.Write(new string('_', Console.WindowWidth));
		}

		static void PrintAddress(Address addr, string indent = "\t")
		{

			Console.WriteLine("{0}{1}", indent, addr.AddressLine1);
			if(!string.IsNullOrEmpty(addr.AddressLine2))
				Console.WriteLine("{0}{1}", indent, addr.AddressLine2);
			Console.WriteLine("{0}{1}, {2}, {3}", indent, addr.City, addr.City, addr.PostalCode);

		}

		static void PrintProduct(Product prod)
		{
			Console.WriteLine(prod.ToString());
		}

		static void PrintItems(Requisition requisition)
		{
			requisition.ItemList.ForEach(PrintItem);
		}

		static void PrintItem(RequisitionItem item)
		{
			Console.WriteLine("UOM: {0}", item.Uom);
			Console.WriteLine("Quantities:");
			PrintQuantityMatrix(item);
			Console.WriteLine(item);
			Console.WriteLine("-----------------------------------------");
		}

		static void PrintQuantityMatrix(RequisitionItem item, string indent = "\t")
		{
			item.QuantityMatrix.ForEach(i=>Console.WriteLine("{0}{1}", indent, i));
		}
	}
}

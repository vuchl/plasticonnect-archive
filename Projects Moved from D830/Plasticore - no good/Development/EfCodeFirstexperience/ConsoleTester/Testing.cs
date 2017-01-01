using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plasticore;

namespace ConsoleTester
{
	public class Testing
	{
		public static void TestCollection()
		{
			var context = new TestingContext();

			/*
				var test = new TestProduct
							{
								Width = 52,
								Gauge = new Gauge {Size = 0.01251m, FullGauge = true},
								Packaging = new Packaging {Type = PackagingType.LbsPerCarton, Value = 100},
								ProductColor = new ProductColor {ResinColor = ResinColor.Blue, Transparency = TransparencyType.Tint},
								ProductNotes = "This is a dummy product",
								UviMonths = 6,
								Printing = new Printing { Coloring = PrintingColoring.NoPrinting},
							};
	*/
			
			
			var found = context.TestCollections.Find(1);

			Console.WriteLine(found);

			foreach (var testItem in found.Items)
			{
				Console.WriteLine(testItem);
			}
		}
	}
}

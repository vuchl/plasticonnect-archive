using System;
using System.Collections.Generic;
using Plasticonnect;
using Plasticore;
using ValidationManager;

namespace ConsoleTester
{
	static class Scenarios
	{
		#region RFQ Related Scenarios

		/// <summary>
		/// This is a scenario outside of the Plasticore that makes caller enable to create a brand new RFQ and edit it.
		/// </summary>
		public static Rfq CreateNewRfq()
		{
			var draft = Core.CreateNewRfq(SampleData.AccountInformation);

			return draft;

		}

		/// <summary>
		/// Submits a brand new RFQ to the plasticore and returns its refrence nubmer
		/// </summary>
		/// <returns>RFQ number</returns>
		public static string SubmitRfq(Rfq newRfq)
		{
			return Core.SubmitRfq(newRfq);
		}

		/// <summary>
		/// Althogh editing of an RFQ is very limited, we need to have this functionality for the support to fix 
		/// possible mistakes. In addition, buyer could be able to edit the RFQ prior visiting by sellers.
		/// </summary>
		public static void EditRfq(Rfq rfq)
		{
			throw new NotImplementedException();
			//rfq.FirstItem.Comments = "[some comments]";
		}

		public static Rfq GetRfqByNumber(string rfqNumber)
		{
			return Core.GetRfqByNumber(rfqNumber);
		}

		/// <summary>
		/// To save possible changes of an RFQ
		/// </summary>
		public static void SaveRfq(Rfq rfq)
		{
			Core.SaveRfq(rfq);
		}

		#endregion

		#region Quote Related Scenarios

		public static Quote CreateQuote(AccountInformation seller, Rfq rfq)
		{
			return Core.CreateNewQuote(seller, rfq);
		}

		public static void EditQuote(Quote quote)
		{
			foreach (var item in quote.Items)
			{
				item.AddQuantitity(1000, 1.2m);
				item.OfferedDeliveryDate = DateTime.Today;
				item.AddCondidtion("[Some conditions added by seller]");
			}

			quote.AdditionalComments = "[Additional comments for quote]";
			quote.ExpiryDate = DateTime.Today.AddDays(30);
		}

		public static void SubmitQuote(Quote quote)
		{
			Core.SubmitQuote(quote);
		}

		public static Quote GetQuoteByNumber(string quoteNumber)
		{
			return Core.GetQuote(quoteNumber);
		}

		public static List<Quote> GetSubmittedQuotes(string rfqNumber)
		{
			throw new NotImplementedException();			
		}

		#endregion 

		#region Order Related Scenarios

		public static void PlaceOrder(string quoteNumber)
		{
			var orders = Core.CreateNewOrder(quoteNumber);
			var i = 1;
			foreach (var order in orders)
			{
				order.BuyerReferenceNumber = "PO10234" + i++;
				Core.PlaceOrder(order);
			}
		}

		#endregion

		#region Product Related Scenarios

		public static void EditProduct(Product prod)
		{
			if(prod is Tubing)
				EditTubing(prod as Tubing);

			prod.Notes = "[some notes about product]";
			prod.PartNumber = "PART#001";
			prod.Slip = SlipType.Regular;
			prod.UviMonths = 6;
			prod.Width = 22.5m;

			if (prod is IGussetable)
				EditGusset((prod as IGussetable).Gusset);

			EditGauge(prod.Gauge);
			EditColorInfo(prod.ColorInfo);
			EditPrinting(prod.Printing);
			EditChemicalAdditives(prod.ChemicalAdditives);
			EditHoles(prod.Holes);
			EditMicrovents(prod.Microvents);
		}

		public static void EditGauge(Gauge gauge)
		{
			gauge.Size = 0.001m;
			gauge.FullGauge = true;
		}

		public static void EditColorInfo(ColorInfo colorInfo)
		{
			colorInfo.ProductColor = ProductColor.Blue;
			colorInfo.Transparency = TransparencyType.Tint;
		}

		public static void EditPrinting(Printing printing)
		{
			printing.Positioning = PrintingPositioning.Random;
			printing.InnerSide = PrintingColoring.NoPrinting;
			printing.OuterSide = PrintingColoring.SingleColor;
			
			printing.Description = "[some printing description]";
		}

		public static void EditMicrovents(Microvents microvents)
		{
			microvents.Type = MicroventType.Spiral;
			microvents.Comments = "[Some comments about microvents]";
		}

		public static void EditHoles(Holes holes)
		{
			holes.HoleSize = HoleSize.OneFourth;
			holes.Quantity = 6;
			holes.Comments = "[Some comments about holes]";
		}

		public static void EditGusset(Gusset gusset)
		{
			gusset.Orientation = GussetOrientation.SideGusset;
			gusset.Size = 2.5m;
		}

		public static void EditChemicalAdditives(ChemicalAdditives chemicalAdditives)
		{
			chemicalAdditives.AntiBlock = true;
			chemicalAdditives.AntiStatic = false;
			chemicalAdditives.FoodFlex = false;
			chemicalAdditives.HighImpact = true;
			chemicalAdditives.Shrink = false;
			chemicalAdditives.Utility = false;
			chemicalAdditives.VirginMaterial = false;
		}

		public static void EditTubing(Tubing tubing)
		{
			tubing.Packaging.Type = Tubing.ValidPackages[0];
			tubing.Packaging.Value = 10;
		}

		#endregion

		private static void DisplayValidationResult(IEnumerable<ValidationResult> list)
		{
			foreach (var validationResult in list)
			{
				Console.WriteLine(validationResult);
			}
		}
	}
}

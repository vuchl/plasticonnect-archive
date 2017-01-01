using System;
using System.Collections.Generic;
using Plasticonnect;
using Plasticore;

namespace ConsoleTester
{

	static class SampleData
	{
//		public static DeliveryInformation RfqDelivery
//		{
//			get
//			{
//				return new DeliveryInformation
//				       	{
//				       		AdditionalComments = "[somoe delivery information comments]",
//				       		Destination = Address,
//				       		Fob = Fob.Destination,
//				       		RequestedDeliveryDate = DateTime.Today
//				       	};
//			}
//		}

		public static Address Address
		{
			get
			{
				return new Address
						{
							AddressLine1 = "address1",
							AddressLine2 = "address2",
							City = "Toronto",
							Province = "Ontario",
							Country = Country.Canada
						};
			}
		}

/*
		public static Contact Contact
		{
			get
			{
				return new Contact
						{
							FullName = "John Doe",
							Email = "jdoe@abc.com",
							Ddt = DocumentDeliveryType.ByEmail,
							PhoneNumber = "4161110000"
						};
			}
		}
*/

		public static List<ItemQuantity> Quantities
		{
			get
			{
				var quantities = new List<ItemQuantity>
				                 	{
				                 		new ItemQuantity {Figure = 100},
				                 		new ItemQuantity {Figure = 200}
				                 	};
				return quantities;
			}
		}

		public static PtoBag PtoBag
		{
			get
			{
				return new PtoBag
				       	{
				       		Width = 24.4m,
				       		Length = 12m,
				       		Gauge = new Gauge {Size = 0.001m, FullGauge = false},
				       		LipHood = new LipHood {HoodSize = 25, LipSize = 1, Type = HoodType.HoodOut},
				       		Gusset = new Gusset {Orientation = GussetOrientation.NoGusset, Size = 5},
				       		Packaging = new Packaging {Type = PackagingType.LbsPerRoll, Value = 20},
				       		ChemicalAdditives = ChemicalAdditives.AntiBlock | ChemicalAdditives.Shrink,
				       		ProductColor =
				       			new ProductColor {ResinColor = ResinColor.Clear, Transparency = TransparencyType.HighClarity},
				       		Printing = new Printing {Coloring = PrintingColoring.SingleColor, Type = PrintingType.Random},
				       	};
			}
		}
	}
}

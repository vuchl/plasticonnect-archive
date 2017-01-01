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

		public static AccountInformation AccountInformation
		{
			get
			{
				return new AccountInformation
				       	{
				       		AccountNumber = "12345",
				       		BillingAddress = Address,
				       		Buyer = Contact,
				       		DefaultCurrency = Currency.Cad
						};
			}
		}

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

		public static List<QuantityMatrix> Quantities
		{
			get
			{
				var quantities = new List<QuantityMatrix>
				                 	{
				                 		new QuantityMatrix {Figure = 100},
				                 		new QuantityMatrix {Figure = 200}
				                 	};
				return quantities;
			}
		}
	}
}

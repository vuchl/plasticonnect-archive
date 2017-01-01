using System;
using System.Collections.Generic;
using System.Data.Entity;
using Plasticonnect;

namespace Plasticore
{
	public class PlasticoreContext : DbContext
	{
		public DbSet<Product> Products { get; set; }
		public DbSet<Requisition> Requisitions { get; set; }

		//		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		//		{
		//			modelBuilder.Entity<TestProduct>().ToTable("TestProducts");
		//		}
	}

	public class TestingContext:DbContext
	{
		public DbSet<TestCollection> TestCollections { get; set; }
	}

	public class PlasticoreContextInitializer : DropCreateDatabaseIfModelChanges<PlasticoreContext>
	{
		protected override void Seed(PlasticoreContext context)
		{
			Console.WriteLine("Re-Seeding database...");

			var rfq = new Rfq
			          	{
			          		AccountNumber = "10001",
							CustomerName = "ABC Co Ltd.",
			          		BillingAddress = new Address
			          		                 	{
			          		                 		AddressLine1 = "100 Gold Street",
			          		                 		AddressLine2 = "",
			          		                 		City = "London",
			          		                 		Province = "Ontario",
			          		                 		PostalCode = "R5S 2K5",
			          		                 		Country = Country.Canada
			          		                 	},
			          		BuyerContact = "John Doe @ 519-444-0000",
			          		Deadline = new DateTime(2012, 3, 25, 12, 0, 0),
			          		ItemList = new List<RequisitionItem>
			          		                      	{
			          		                      		new RfqItem
			          		                      			{
			          		                      				Product = new PtoBag
			          		                      				          	{
			          		                      				          		Width = 54,
			          		                      				          		Length = 60,
			          		                      				          		Gusset = new Gusset
			          		                      				          		         	{
			          		                      				          		         		Orientation = GussetOrientation.SideGusset,
			          		                      				          		         		Size = 44
			          		                      				          		         	},
			          		                      				          		Gauge = new Gauge
			          		                      				          		        	{
			          		                      				          		        		FullGauge = false,
			          		                      				          		        		Size = 0.001m
			          		                      				          		        	},
			          		                      				          		ChemicalAdditives = ChemicalAdditives.AntiBlock & ChemicalAdditives.AntiStatic,
			          		                      				          		Slip = SlipType.Regular,
			          		                      				          		ProductColor = new ProductColor
			          		                      				          		               	{
			          		                      				          		               		ResinColor = ResinColor.Clear,
			          		                      				          		               		Transparency = TransparencyType.RegularClarity
			          		                      				          		               	},
			          		                      				          		Packaging = new Packaging
			          		                      				          		            	{
			          		                      				          		            		Type = PackagingType.QtyPerRoll,
			          		                      				          		            		Value = 100
			          		                      				          		            	},
			          		                      				          		Printing = new Printing
			          		                      				          		           	{
			          		                      				          		           		Coloring = PrintingColoring.TwoColor,
			          		                      				          		           		Type = PrintingType.Random,
			          		                      				          		           	},
			          		                      				          		LipHood = new LipHood
			          		                      				          		          	{
			          		                      				          		          		Type = HoodType.None
			          		                      				          		          	}
			          		                      				          	},
			          		                      				Uom = Uom.M1000,
			          		                      				QuantityMatrix = new List<ItemQuantity>
			          		                      				                 	{
			          		                      				                 		new ItemQuantity {Figure = 1000},
			          		                      				                 		new ItemQuantity {Figure = 2000},
			          		                      				                 		new ItemQuantity {Figure = 2500},
			          		                      				                 	},
			          		                      			},
			          		                      		new RfqItem
			          		                      			{
			          		                      				Product = new Tubing
			          		                      				          	{
			          		                      				          		Width = 44,
			          		                      				          		Gusset = new Gusset
			          		                      				          		         	{
			          		                      				          		         		Size = 3,
			          		                      				          		         		Orientation = GussetOrientation.SideGusset
			          		                      				          		         	},
			          		                      				          		Gauge = new Gauge {Size = 0.00125m},
			          		                      				          		Slip = SlipType.Regular,
			          		                      				          		ProductColor = new ProductColor
			          		                      				          		               	{
			          		                      				          		               		Transparency = TransparencyType.RegularClarity,
			          		                      				          		               		ResinColor = ResinColor.Clear
			          		                      				          		               	},
			          		                      				          		Packaging = new Packaging
			          		                      				          		            	{
			          		                      				          		            		Type = PackagingType.LbsPerRoll,
			          		                      				          		            		Value = 20
			          		                      				          		            	},
			          		                      				          		Printing = new Printing
			          		                      				          		           	{
			          		                      				          		           		Coloring = PrintingColoring.NoPrinting,
			          		                      				          		           		Type = PrintingType.Random
			          		                      				          		           	}
			          		                      				          	},
			          		                      				Uom = Uom.Lbs,
			          		                      				QuantityMatrix = new List<ItemQuantity>
			          		                      				                 	{
			          		                      				                 		new ItemQuantity {Figure = -1}
			          		                      				                 	}
			          		                      			}
			          		                      	},
			          		AdditionalComments = null,
			          		RequestedCurrency = Currency.Cad
			          	};

			context.Requisitions.Add(rfq);

/*
			var customers = new List<AccountInformation>
			               	{
			               		new AccountInformation
			               			{
			               				AccountNumber = "10001",
			               				BillingAddress = new Address
			               				                 	{
			               				                 		AddressLine1 = "100 Gold Street",
			               				                 		City = "London",
			               				                 		Province = "Ontario",
			               				                 		PostalCode = "R5S 2K5"
			               				                 	},
			               				Contacts = new List<Contact>
			               				           	{
			               				           		new Contact
			               				           			{
			               				           				FullName = "John Doe",
			               				           				Email = "john.doe@comp1.com",
			               				           				PhoneNumber = "519-444-0000"
			               				           			},
			               				           		new Contact
			               				           			{
			               				           				FullName = "Marry Hapkins",
			               				           				Email = "marry.hapkins@comp1.com",
			               				           				PhoneNumber = "519-444-0002"
			               				           			}
			               				           	},
			               				DefaultCurrency = Currency.Cad

			               			},
			               		new AccountInformation
			               			{
			               				AccountNumber = "10002",
			               				BillingAddress = new Address
			               				                 	{
			               				                 		AddressLine1 = "450 Bay Street",
			               				                 		City = "Toronto",
			               				                 		Province = "Ontario",
			               				                 		PostalCode = "M4A 2K3"
			               				                 	},
			               				Contacts = new List<Contact>
			               				           	{
			               				           		new Contact
			               				           			{
			               				           				FullName = "Mike Port",
			               				           				Email = "mike.port@comp2.com",
			               				           				PhoneNumber = "416-444-0000"
			               				           			},
			               				           	},
			               				DefaultCurrency = Currency.Cad

			               			}
			               	};

			customers.ForEach(c=>context.Customers.Add(c));
*/

			base.Seed(context);
		}
	}

	public class TestingContextInitializer: DropCreateDatabaseIfModelChanges<TestingContext>
	{
		protected override void Seed(TestingContext context)
		{
			Console.WriteLine("Re-Seeding database from the testing context...");

			var test = new TestCollection
			           	{
			           		Name = "Test Collection 1",
			           		Items = new List<TestItem>
			           		        	{
			           		        		new TestItem {Name = "Item 1-1"},
			           		        		new TestItem {Name = "Item 1-2"},
			           		        		new TestItem {Name = "Item 1-3"},
			           		        	}
			           	};
			context.TestCollections.Add(test);

			base.Seed(context);
		}
	}
}

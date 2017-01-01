using System.Linq;
using System.Xml.Serialization;

namespace XmlSerializing
{
	/// <summary />
	[XmlRoot("Order", IsNullable = false)]
	public class PurchaseOrder
	{
		[XmlAttribute]
		public int OrderNumber { get; set; }

		/// <summary />
		public Address ShipTo { get; set; }

		/// <summary />
		public string OrderDate { get; set; }

		/* The XmlArrayAttribute changes the XML element name
		 from the default of "OrderedItems" to "Items". */
		/// <summary />
		[XmlArrayAttribute("Items", IsNullable=false)]
		public OrderedItem[] OrderedItems { get; set; }

		/// <summary />
		[XmlElement(IsNullable = false )]
		public decimal SubTotal
		{
			get 
			{
				return OrderedItems.Sum(oi => oi.LineTotal);
			}

// ReSharper disable ValueParameterNotUsed
			set { }
// ReSharper restore ValueParameterNotUsed
		}

		/// <summary />
		public decimal ShipCost { get; set; }

		/// <summary />
		public decimal TotalCost { get; set; }

		public decimal? NullableDecimal { get; set; }
		public bool ShouldSerializeNullableDecimal()
		{
			return NullableDecimal.HasValue;
		}
	}
}

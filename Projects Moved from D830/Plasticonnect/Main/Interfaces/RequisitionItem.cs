using System.Collections.Generic;

namespace Plasticonnect.Engine
{
	public class Quantity
	{
		/// <summary>
		/// Describes who has provided the quantity
		/// </summary>
		public enum QuntityType
		{
			/// <summary>
			/// Indicates that quantity is requested by buyer
			/// </summary>
			Requested, 

			/// <summary>
			/// Indicates that quantity is offered by seller
			/// </summary>
			Offered,
		}

		/// <summary>
		/// The actual quantity value
		/// </summary>
		public int Figure { get; set; }

		/// <summary>
		/// Price assigned by seller to the provided quantity
		/// </summary>
		public decimal Price { get; set; } //todo: remove access from RFQ
	}

	public abstract class RequisitionItem
	{
		/// <summary>
		/// Different quantities for the item that can be asked by buyer or offered by seller
		/// </summary>
		public List<Quantity> Quantities { get; set; }
		public Product Product{ get; set; }
		public Uom Uom { get; set; }

		public DeliveryInformation Delivery { get; set; }

		/// <summary>
		/// item specific comments
		/// </summary>
		public string Comments { get; set; }
	}
}

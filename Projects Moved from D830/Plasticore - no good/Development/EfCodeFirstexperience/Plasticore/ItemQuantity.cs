using System.ComponentModel.DataAnnotations;

namespace Plasticore
{
	[Table("QuantityMatrices")]
	public class ItemQuantity
	{
		public int Id { get; set; }

		/// <summary>
		/// Describes who has provided the quantity
		/// </summary>
		public enum QuantityType
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

		public QuantityType QauntityType { get; set; }
	
		/// <summary>
		/// The actual quantity value
		/// </summary>
		public int Figure { get; set; }

		/// <summary>
		/// Price assigned by seller to the provided quantity
		/// </summary>
		public decimal Price { get; set; } //todo: remove access from RFQ

		public override string ToString()
		{
			return string.Format("{0} ({1})", Figure, QauntityType);
		}
	}
}
using System.ComponentModel;

namespace Plasticonnect.Engine
{
	/// <summary>
	/// Offers the possible types of transparency of a product
	/// Can be RegularClarity, HighClarity, Opaque or Tint
	/// </summary>
	public enum TransparencyType
	{
		// -----------------------------------------------------
		// Important Notes:
		// Any changes to the regular clarity in this enum
		// should be reflected on tblRecipieCombinations
		// -----------------------------------------------------

		/// <summary>
		/// indicates no-color regular clarity of the product
		/// </summary>
		[Description("")]
		RegularClarity = 0,

		/// <summary>
		/// indicates no-color high-clarity of the product
		/// </summary>
		[Description("")]
		HighClarity = 1,

		/// <summary>
		/// indicates colored none see-through product
		/// </summary>
		[Description("Opaque")]
		Opaque = 2,

		/// <summary>
		/// indicates colored see-through product
		/// </summary>
		[Description("Tint")]
		Tint = 3
	}
}

using System.ComponentModel;

namespace Plasticonnect
{
	/// <summary>
	/// Defines where on product to do the sealing: Bottom or Side
	/// </summary>
	public enum SealingType : short
	{
		/// <summary>
		/// not all products has sealing.
		/// </summary>
		[Description("Not Applicable")]
		NotApplicable = 0,

		/// <summary>
		/// bottom sealed
		/// </summary>
		[Description("Bottom Sealed")]
		Bottom = 1,

		/// <summary>
		/// side sealed
		/// </summary>
		[Description("Side Sealed")]
		Side = 2
	}
}
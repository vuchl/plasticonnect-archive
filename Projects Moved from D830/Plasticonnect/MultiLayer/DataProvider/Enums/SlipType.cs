using System.ComponentModel;

namespace Plasticonnect.DataProvider.Enums
{
	/// <summary>
	/// Defines the slippage level of the product
	/// Can be Regular, Low, Medium or High
	/// </summary>
	public enum SlipType : short 
	{
		/// <summary>
		/// regular slip
		/// </summary>
		[Description("Regular")]
		Regular = 0,

		/// <summary>
		/// low slip
		/// </summary>
		[Description("Low")]
		Low = 1,

		/// <summary>
		/// medium slip
		/// </summary>
		[Description("Medium")]
		Medium = 2,

		/// <summary>
		/// high slip
		/// </summary>
		[Description("High")]
		High = 3
	}
}
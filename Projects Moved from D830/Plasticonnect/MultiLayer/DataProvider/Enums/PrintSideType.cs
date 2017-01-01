using System.ComponentModel;

namespace Plasticonnect.DataProvider.Enums
{
	/// <summary>
	/// Defines the side of the product that the print is going 
	/// to be done on and number of colors that is goind to be used
	/// Can be OneColorOneSide, OneColorTwoSide or TwoColorOneSide
	/// </summary>
	public enum PrintSideType
	{
		/// <summary>
		/// One Color - One Side
		/// </summary>
		[Description("One Color One Side")]
		OneColorOneSide = 0,

		/// <summary>
		/// One Color - Two Sides
		/// </summary>
		[Description("One Color Two Sides")]
		OneColorTwoSide = 1,

		/// <summary>
		/// Two Color - One Side
		/// </summary>
		[Description("Two Colors One Side")]
		TwoColorOneSide = 2
	}
}
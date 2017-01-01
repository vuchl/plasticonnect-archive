using System.ComponentModel;

namespace Plasticore
{
	/// <summary>
	/// Defines number of colors that is printed on a single side of the product
	/// </summary>
	public enum PrintingColoring
	{
		/// <summary>
		/// No printing is done on the surface
		/// </summary>
		NoPrinting = 0,

		/// <summary>
		/// Single Color Printing
		/// </summary>
		[Description("Single Color")]
		SingleColor = 1,

		/// <summary>
		/// Two Colors
		/// </summary>
		[Description("Two Colors")]
		TwoColor = 2,

		/// <summary>
		/// Multiple Color
		/// </summary>
		[Description("More Than Tow Colors")]
		MultipleColor = 3,

		/// <summary>
		/// Digital Printing
		/// </summary>
		[Description("Digital Printing")]
		Digital = 100
	}
}

using System.ComponentModel;

namespace Plasticore
{
	/// <summary>
	/// Offers the possible direction of text on a product when printing
	/// Can be Downward, Upward, Regular or Upsidedown 
	/// </summary>
	/// <remarks>it was TextDirectionBagOrientation group in lookup table</remarks>
	public enum TextDirectionType
	{
		/// <summary>
		/// Any direction, Regency decides
		/// </summary>
		[Description("Any")]
		Unknown = 0,

		/// <summary>
		/// Downward starting from opening to the sealed part of the bag
		/// </summary>
		[Description("Downward")]
		Downward = 1,

		/// <summary>
		/// Upward starting from sealed to the opening part of the bag
		/// </summary>
		[Description("Upward")]
		Upward = 2,

		/// <summary>
		/// Upward against the bag opening. This is good when the bag is litterally bag
		/// </summary>
		[Description("Regular")]
		Regular = 3,

		/// <summary>
		/// Downward against the bag opening. This is good for cover bags with are upside down
		/// </summary>
		[Description("Upsidedown")]
		Upsidedown = 4
	}
}

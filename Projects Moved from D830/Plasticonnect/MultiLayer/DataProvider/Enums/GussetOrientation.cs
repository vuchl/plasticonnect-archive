using System.ComponentModel;

namespace Plasticonnect.DataProvider.Enums
{
	/// <summary>
	/// Defines the orientation of gusset on a product
	/// It can be NoGussete, SideGusset or BottomGusset
	/// </summary>
	public enum GussetOrientation
	{
		/// <summary>
		/// no gusset
		/// </summary>
		[Description("No Gusset")]
		NoGusset = 0,

		/// <summary>
		/// gusset on the side
		/// </summary>
		[Description("Side Gusset")]
		SideGusset = 1,

		/// <summary>
		/// gusset on the bottom
		/// </summary>
		[Description("Bottom Gusset")]
		BottomGusset = 2
	}
}
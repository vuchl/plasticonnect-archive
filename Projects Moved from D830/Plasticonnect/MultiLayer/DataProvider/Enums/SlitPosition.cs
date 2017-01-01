using System.ComponentModel;

namespace Plasticonnect.DataProvider.Enums
{
	/// <summary>
	/// Defines the possible slit positions<br />
	/// sides are based on looking at the horizontal roll when it is opening from top
	/// Can be None, Left, Right or Middle
	/// </summary>
	public enum SlitPosition
	{
		/// <summary>
		/// Regency decides which side to put the slit
		/// </summary>
		[Description("Regency Decides")]
		RegencyDecides = 0,

		/// <summary>
		/// slit on the left side
		/// </summary>
		[Description("Left Slit")]
		Left = 1,

		/// <summary>
		/// slit on the right side
		/// </summary>
		[Description("Right Slit")]
		Right = 2,

		/// <summary>
		/// slit in the middle
		/// </summary>
		[Description("Middle Slit")]
		Middle = 3
	}
}
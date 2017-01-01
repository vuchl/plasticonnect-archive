using System.ComponentModel;

namespace Plasticore
{
	/// <summary>
	/// Defines the hood type on a bag
	/// It can be None, HoodIn or HoodOut
	/// </summary>
	public enum HoodType
	{
		/// <summary>
		/// bag has no extension
		/// </summary>
		[Description("None")]
		None = 0,

		/// <summary>
		/// bag has hood going inside
		/// </summary>
		[Description("In-Hood")]
		HoodIn = 2,

		/// <summary>
		/// bag has hood going outside
		/// </summary>
		[Description("Out-Hood")]
		HoodOut = 3,
	}
}
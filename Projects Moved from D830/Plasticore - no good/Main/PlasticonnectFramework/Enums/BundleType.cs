using System.ComponentModel;

namespace Plasticonnect
{
	/// <summary>
	/// Defines the type of the bundle
	/// Can be Wicketed or Hotrod
	/// </summary>
	public enum BundleType
	{
		/// <summary>
		/// no bundle, bags are separate
		/// </summary>
		[Description("No Bundle")]
		NoBundle = 0,

		/// <summary>
		/// bags are bundled in a piece of rod going to the wicket holes
		/// </summary>
		[Description("Wicketed")]
		Wicketed = 1,

		/// <summary>
		/// bags are bundled with a hot rod attached to each other
		/// </summary>
		[Description("Hot Rod")]
		HotRod = 2
	}
}

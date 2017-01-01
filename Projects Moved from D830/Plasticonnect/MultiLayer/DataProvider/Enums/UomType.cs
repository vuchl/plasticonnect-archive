using System.ComponentModel;

namespace Plasticonnect.DataProvider.Enums
{
	/// <summary>
	/// Indicate different possible Unit Of Measurements
	/// </summary>
	public enum UOMType
	{
		/// <summary>
		/// undefined UOM
		/// </summary>
		[Description("None")]
		None = 0,
        
		/// <summary>
		/// Lbs (pounds)
		/// </summary>
		[Description("Lbs")]
		Lbs = 1,

		/// <summary>
		/// Rolls
		/// </summary>
		[Description("Rolls")]
		Rolls = 2,

		/// <summary>
		/// One thousand items
		/// </summary>
		[Description("M")]
		M1000 = 3,

		/// <summary>
		/// Carton
		/// </summary>
		[Description("Carton")]
		Carton = 4
	}
}
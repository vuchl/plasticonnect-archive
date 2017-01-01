using System.ComponentModel;

namespace Plasticore
{
	/// <summary>
	/// Represents the choices that are available for Packaging
	/// </summary>
	public enum PackagingType
	{
		/// <summary>
		/// No preferences
		/// </summary>
		[Description("No Preferences")]
		NoPreferences = 0,

		/// <summary>
		/// Lbs per Roll
		/// </summary>
		[Description("Lbs Per Roll")]
		LbsPerRoll = 1,

		/// <summary>
		/// Lbs per Carton
		/// </summary>
		[Description("Lbs Per Carton")]
		LbsPerCarton = 2,

		/// <summary>
		/// Square Feet per Roll
		/// </summary>
		[Description("SqFt Per Roll")]
		SqFtPerRoll = 3,

		/// <summary>
		/// Linear Feet per Roll
		/// </summary>
		[Description("LnFt Per Roll")]
		LnFtPerRoll = 4,

		/// <summary>
		/// Quantity per Roll
		/// </summary>
		[Description("Qty Per Roll")]
		QtyPerRoll = 5,

		/// <summary>
		/// Quantity per Carton
		/// </summary>
		[Description("Qty Per Carton")]
		QtyPerCarton = 6,
	}

}

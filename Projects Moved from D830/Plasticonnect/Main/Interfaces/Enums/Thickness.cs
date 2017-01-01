using System.ComponentModel;

namespace Plasticonnect.Engine
{
	/// <summary>
	/// Thickness types of CGP products
	/// </summary>
	public enum Thickness
	{
		/// <summary>
		/// Unknown Thickness
		/// </summary>
		[Description("Unknown")]
		Unknown = 0,

		/// <summary>
		/// Utitlity
		/// </summary>
		[Description("Utility")]
		Utility = 1,

		/// <summary>
		/// Light
		/// </summary>
		[Description("Light")]
		Light = 2,

		/// <summary>
		/// Medium
		/// </summary>
		[Description("Medium")]
		Medium = 3,

		/// <summary>
		/// Heavy
		/// </summary>
		[Description("Heavy")]
		Heavy = 4,

		/// <summary>
		/// Super
		/// </summary>
		[Description("Super")]
		Super = 5,

		/// <summary>
		/// CGSB
		/// </summary>
		[Description("CGSB")]
		Cgsb = 6
	}
}
using System.ComponentModel;

namespace Plasticonnect.DataProvider.Enums
{
	/// <summary>
	/// Defines the type of the EyeMark in printing
	/// Possible choices are Unknown, Plain or Logo
	/// </summary>
	public enum EyeMarkType
	{
		/// <summary>
		/// Not Specified
		/// </summary>
		[Description("Not Specified")]
		Unknown = 0,

		/// <summary>
		/// Plain
		/// </summary>
		[Description("Plain")]
		Plain = 1,

		/// <summary>
		/// Logo provided
		/// </summary>
		[Description("Logo")]
		Logo = 2
	}
}
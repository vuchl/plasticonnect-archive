using System.ComponentModel;

namespace Plasticonnect.DataProvider.Enums
{
	/// <summary>
	/// Indicates whether the bag's end or open end should be sealed first
	/// </summary>
	public enum SealedFirstType : short
	{
		/// <summary>
		/// no preferences
		/// </summary>
		[Description("No Preferences")]
		NotSpecified = 0,

		/// <summary>
		/// seald end first.
		/// </summary>
		[Description("Sealed End First")]
		SealedEndFirst = 1,

		/// <summary>
		/// open end first
		/// </summary>
		[Description("Open End First")]
		OpenEndFirst = 2
	}
}

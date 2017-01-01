using System.ComponentModel;

namespace Plasticonnect.DataProvider.Enums
{
	/// <summary>
	/// Defines the category of CGP. Is being used to create the title of CGP
	/// </summary>
	public enum CgpType
	{
		[Description("Clear")]
		Clear = 0,

		[Description("CGSB")]
		Cgsb = 1,

		[Description("Colored")]
		Colored = 2,

		[Description("Black")]
		Black = 3
	}
}
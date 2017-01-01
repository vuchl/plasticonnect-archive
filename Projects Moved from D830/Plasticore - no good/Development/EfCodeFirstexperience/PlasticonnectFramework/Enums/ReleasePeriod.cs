using System.ComponentModel;

namespace Plasticonnect
{
	public enum ReleasePeriod
	{
		/// <summary>
		/// Used for the single release items. 
		/// Uses delivery date for the scheduled date. 
		/// todo: Hamed, check if we need this
		/// </summary>
		[Description("Scheduled")]
		Scheduled = 0,

		/// <summary>
		/// Three-Month Releases
		/// </summary>
		[Description("Three Months")]
		ThreeMonth = 3,

		/// <summary>
		/// Four-Month Releases
		/// </summary>
		[Description("Four Months")]
		FourMounth = 4,

		/// <summary>
		/// Six-Month Releases
		/// </summary>
		[Description("Six Months")]
		SixMonth = 6,

		/// <summary>
		/// Eight-Month Releases
		/// </summary>
		[Description("Eight Months")]
		EightMonth = 8,

		/// <summary>
		/// One-Year Releases
		/// </summary>
		[Description("One Year")]
		OneYear = 12
	}
}

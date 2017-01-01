using System.ComponentModel;

namespace Plasticonnect.DataProvider.Enums
{
	/// <summary>
	/// Account dealing currency 
	/// </summary>
	public enum AccountCurrency
	{
		/// <summary>
		/// Canadian Currency
		/// </summary>
		[Description("Canadian Dollar")]
		CAD = 1,

		/// <summary>
		/// States Currency
		/// </summary>
		[Description("U.S. Dollar")]
		Usd = 2,

	}
}
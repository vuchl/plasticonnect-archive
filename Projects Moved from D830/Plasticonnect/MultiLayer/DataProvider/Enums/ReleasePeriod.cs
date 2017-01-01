using System.ComponentModel;

namespace Plasticonnect.DataProvider.Enums
{
	/// <summary>
	/// Offers the possible choices of ReleasePeriod
	/// Can be Immediate, OneMonth, FortyFiveDays, TwoMonths, ThreeMonths or SixMonths
	/// </summary>
	public enum ReleasePeriod
	{
		// note:(lookup) ID and int values mismatching
		// note: description added due to Order class usage

		/// <summary>
		/// item will be released as soon as order is placed
		/// </summary>
		[Description("0")]
		Immediate = 0,

		/// <summary>
		/// item will be released in a month
		/// </summary>
		[Description("30")]
		OneMonth = 10,

		/// <summary>
		/// item will be released in 45 days
		/// </summary>
		[Description("45")]
		FortyFiveDays = 15,

		/// <summary>
		/// item will be released in two months
		/// </summary>
		[Description("60")]
		TwoMonths = 20,

		/// <summary>
		/// item will be released in three months
		/// </summary>
		[Description("90")]
		ThreeMonths = 30,

		/// <summary>
		/// item will be released in six months
		/// </summary>
		[Description("180")]
		SixMonths = 60
	}
}
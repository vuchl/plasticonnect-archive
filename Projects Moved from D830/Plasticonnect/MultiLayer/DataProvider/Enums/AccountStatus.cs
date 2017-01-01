using System.ComponentModel;

namespace Plasticonnect.DataProvider.Enums
{
	/// <summary>
	/// Status of an Account in the sales cycle
	/// </summary>
	public enum AccountStatus
	{

		/// <summary>
		/// Account has no Requisition yet and it mught be a user in the future
		/// </summary>
		[Description("Prospect")]
		Prospect = 0,


		/// <summary>
		/// Account belongs to an Active Customer that has Requisition submitted during the last 12 months
		/// </summary>
		[Description("Active")]
		Active = 1,


		/// <summary>
		/// Company is Out of Business
		/// </summary>
		[Description("OUB")]
		OutOfBusiness = 2,

		/// <summary>
		/// Account is temporary On-Hold since it has an issue (usually credit issue)
		/// </summary>
		[Description("OnHold")]
		OnHold = 3,


		/// <summary>
		/// Account used to be Active and it has changed to Dormant since no Requisition has been submitted in the last  12 months.
		/// </summary>
		[Description("Dormant")]
		Dormant = 4,


		/// <summary>
		/// They are in business but they are not using Poly or they use under the limit
		/// </summary>
		[Description("")]
		NonUser = 5
	}
}
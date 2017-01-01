namespace Plasticonnect.DataProvider.Enums
{
	/// <summary>
	/// Represents the type of the contacts
	/// </summary>
	public enum ContactType
	{
		/// <summary>
		/// MainBuyer in RIS. Salesreps are allowed to CUD contacts of this type.
		/// </summary>
		SalesRep = 425,

		/// <summary>
		/// AP in RIS. Regency's A/P is allowed to CUD contacts of this type.
		/// </summary>
		AccountReceivible = 426,

		/// <summary>
		/// Other contacts in RIS. Regency's CSRs are allowed to create contacts of this type.
		/// </summary>
		CustomerServiceRep = 424,

		/// <summary>
		///  Customers are allowed to create contacts of this type.
		/// </summary>
		Customer = 427
	}
}
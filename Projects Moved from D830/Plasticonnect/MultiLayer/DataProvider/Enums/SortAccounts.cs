namespace Plasticonnect.DataProvider.Enums
{
	/// <summary>
	/// Defines the type of sorts on Accounts
	/// Possible choices are Account name, Postal code or AccountNumber
	/// </summary>
	public enum SortAccounts
	{
		/// <summary>
		/// Sorting by Account Name
		/// </summary>
		AccountName = 2,

		/// <summary>
		/// Sorting by Postal Code
		/// </summary>
		PostalCode=4,

		/// <summary>
		/// Sorting by Account Number
		/// </summary>
		AccountNumber = 8
	}
}
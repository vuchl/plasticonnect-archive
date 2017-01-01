namespace Plasticonnect.DataProvider.Enums
{
	/// <summary>
	/// Defines the type of an address
	/// The type can be Billing or Ship-to
	/// </summary>
	public enum AddressType
	{
		/// <summary>
		/// main address of the company and the address that we send the invoice
		/// </summary>
		BillingTo, // value 0
		/// <summary>
		/// any additional address that can use for destination for the shipping department
		/// </summary>
		ShipTo	  // value 1	
	}

}

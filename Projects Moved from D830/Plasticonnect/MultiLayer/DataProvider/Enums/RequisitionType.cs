namespace Plasticonnect.DataProvider.Enums
{
	/// <summary>
	/// Type of requisition
	/// </summary>
	public enum RequisitionType
	{
		/// <summary>
		/// requisition is a Draft and has not been submitted  yet
		/// </summary>
		Draft = 0x0000,

		/// <summary>
		/// requistiion is a submitted Quote
		/// </summary>
		Quote = 0x1000,

		/// <summary>
		/// requisition is an Order
		/// </summary>
		Order = 0x2000,
	}
}
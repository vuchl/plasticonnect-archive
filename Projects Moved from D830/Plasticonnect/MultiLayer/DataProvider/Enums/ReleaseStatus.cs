namespace Plasticonnect.DataProvider.Enums
{
	/// <summary>
	/// Represents the status of a Release in its life cycle
	/// </summary>
	public enum ReleaseStatus
	{
		/// <summary>
		/// There is no actual relase yet and this is an estimation only
		/// </summary>
		Open = 0, // 0x0000,

		/// <summary>
		/// Customer has issued the release which means has to be in progress of shipping
		/// </summary>
		Issued = 4352, // 0x1100,

		/// <summary>
		/// CSR has confirmed the release and it is ready for shipping
		/// </summary>
		Confirmed = 4608, // 0x1200,

		/// <summary>
		/// release has been delivered to the customer
		/// </summary>
		Shipped = 8192, // 0x03000
	}
}
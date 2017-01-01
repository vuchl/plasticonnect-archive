namespace Plasticonnect
{
	public enum Fob
	{
		/// <summary>
		/// To be shipped to the destination address
		/// Destination address should be identified in in RFQ.
		/// </summary>
		Destination,

		/// <summary>
		/// To be picked up from the sellers warehouse;
		/// Pickup location (Warehouse) should be identified in the Quote.
		/// </summary>
		Pickup
	}
}
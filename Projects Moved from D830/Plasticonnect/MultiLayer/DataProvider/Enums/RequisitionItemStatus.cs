namespace Plasticonnect.DataProvider.Enums
{
	/// <summary>
	/// keeps tracking of the saving status of an item
	/// </summary>
	public enum RequisitionItemStatus
	{
		/// <summary>
		/// item has not been saved and is in memory
		/// </summary>
		OnTheFly,

		/// <summary>
		/// item has been saved in the Regency databased but not synched with RegencyRef yet (draft items)
		/// </summary>
		TemporarySaved,

		/// <summary>
		/// item either has been synched with RegencyRef or it exist only on RegencyRef. <br />
		/// in both condition, item has a valid orderDetailNumber
		/// </summary>
		FullySaved
	}
}
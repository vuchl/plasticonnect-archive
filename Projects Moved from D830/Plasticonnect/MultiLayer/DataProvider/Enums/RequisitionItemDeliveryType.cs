namespace Plasticonnect.DataProvider.Enums
{
	/// <summary>
	/// specifies the type of item delivery
	/// </summary>
	public enum RequisitionItemDeliveryType : byte
	{
		/// <summary>
		/// item is a reqular single delivery to a single FOB
		/// </summary>
		SingleRelease = 0,

		/// <summary>
		/// blanket item; item has more than one relases however to a single Fob
		/// </summary>
		MultiReleaseSingleFob = 1,

		/// <summary>
		/// blanket item; item has more than one relases each could be to different Fob
		/// <remarks>NOTES:<br />
		/// This is a very rare situation and it happens only for the distributors that wants
		/// the delivery to a certain area. All the locations will be in the same area
		/// otherwise prices would be different. 
		/// </remarks>
		/// </summary>
		MultiReleaseMultiFob = 2
	}

}

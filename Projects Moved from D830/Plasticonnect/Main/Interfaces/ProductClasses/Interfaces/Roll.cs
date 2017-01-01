namespace Plasticonnect.Engine
{
	/// <summary>
	/// Represent a Roll product class in Regency products (CGP, PtoBag, PtoSheet, PtoSleeve, Sheeting and Tubing)
	/// </summary>
	// ReSharper disable InconsistentNaming
	public interface Roll
		// ReSharper restore InconsistentNaming
	{
		/// <summary>
		/// Number of Rolls on a skid
		/// </summary>
		short RollsPerSkid { get; }

		//		/// <summary>
		//		/// diameter of a roll (Optional)
		//		/// </summary>
		//		short diameterPerRoll { get; set; }
	}
}
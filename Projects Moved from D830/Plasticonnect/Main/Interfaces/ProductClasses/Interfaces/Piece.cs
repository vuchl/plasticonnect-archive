namespace Plasticonnect.Engine
{
	/// <summary>
	/// Represent a Piece form of the products (all PTO's and Looses)
	/// </summary>
	// ReSharper disable InconsistentNaming
	public interface Piece
		// ReSharper restore InconsistentNaming
	{
		/// <summary>
		/// Length of the sheet
		/// </summary>
		decimal Length { get; set; }
	}
}
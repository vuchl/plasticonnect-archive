namespace Plasticonnect.Engine
{
	/// <summary>
	/// Represent a flat form on the roll product class in Regency products (Sheeting, PTOSheet or CGP)
	/// </summary>
	// ReSharper disable InconsistentNaming
	public interface Flat
		// ReSharper restore InconsistentNaming
	{
		/// <summary>
		/// Provides information about the product folding
		/// </summary>
		FoldingInfo FoldingInfo { get; }
	}
}
namespace Plasticore
{
	/// <summary>
	/// represents a Bag product (PTOBags or LooseBags)
	/// </summary>
	// ReSharper disable InconsistentNaming
	public interface Bag : Piece, IGussetable
		// ReSharper restore InconsistentNaming
	{
		/// <summary>
		/// indicates if the LooseBag has Hood
		/// </summary>
		bool HasHood { get; }

		/// <summary>
		/// indicates if the LooseBag has Lip
		/// </summary>
		bool HasLip { get; }

		/// <summary>
		/// Indicates whether the bag should be leak-proof or not
		/// </summary>
		bool LeakProof { get; set; }

		/// <summary>
		/// Indicates whether the product has lip or hood or not.
		/// For more detail refer to LipHood class
		/// </summary>
		LipHood LipHood { get; }

		/// <summary>
		/// Indicates the type of sealing
		/// Refer to SealingType for possible options
		/// </summary>
		SealingType Sealing { get; set; }
	}
}
using System.ComponentModel;

namespace Plasticonnect.DataProvider.Enums
{
	/// <summary>
	/// Indicates the possible types of products supported by RegencyObjects
	/// Can be PTOBag, Sheeting, Tubing, CGP, LooseBag, LooseSheet, PTOSheet or PTOSleeve
	/// </summary>
	public enum ProductType
	{
		/// <summary>
		/// unknown product
		/// </summary>
		[Description("Unknown")]
		Unknown = 0,

		/// <summary>
		/// PTO Bag
		/// </summary>
		[Description("PTO Bag")]
		PtoBag = 1,

		/// <summary>
		/// Sheeting
		/// </summary>
		[Description("Sheeting")]
		Sheeting = 2,

		/// <summary>
		/// Tubing
		/// </summary>
		[Description("Tubing")]
		Tubing = 3,

		/// <summary>
		/// CGP (Construction Grade Poly or Vapour Barrier)
		/// </summary>
		[Description("CGP")]
		Cgp = 4,

		/// <summary>
		/// Loose Bag
		/// </summary>
		[Description("Loose Bag")]
		LooseBag = 5,

		/// <summary>
		/// Loose Sheet
		/// </summary>
		[Description("Loose Sheet")]
		LooseSheet = 6,

		/// <summary>
		/// PTO Sheet
		/// </summary>
		[Description("PTO Sheet")]
		PtoSheet = 7,

		/// <summary>
		/// PTO Sleeve
		/// </summary>
		[Description("PTO Sleeve")]
		PtoSleeve = 8
	}
}
using System.ComponentModel;

namespace Plasticonnect.DataProvider.Enums
{
    /// <summary>
    /// Defines the color of a sleeve which is used to cover a roll
    /// </summary>
	public enum SleeveColor : short
	{
		/// <summary>
		/// Regency choose the best price sleeve based on the inventory
		/// </summary>
		[Description("Best Price")]
		RegencyDecides = 0,

		/// <summary>
		/// Clear Sleeves
		/// </summary>
		[Description("Clear")]
		Clear = 1,

		/// <summary>
		/// Black Sleeves
		/// </summary>
		[Description("Black")]
		Black = 2,

		/// <summary>
		/// Red Sleeves
		/// </summary>
		[Description("Red")]
		Red = 3,

		/// <summary>
		/// Blue Sleeves
		/// </summary>
		[Description("Blue")]
		Blue = 4,

		/// <summary>
		/// Green Sleeves
		/// </summary>
		[Description("Green")]
		Green = 5
	}
}
using System.ComponentModel;

namespace Plasticonnect.DataProvider.Enums
{
	/// <summary>
	/// Delivery Types
	/// </summary>
	public enum FOB
	{
		/// <summary>
		/// customer will pick up the goods
		/// </summary>
		[Description("Pickup")]
		Pickup = 0,

		/// <summary>
		/// regency deliver the goods to the destication address
		/// </summary>
		[Description("Destination")]
		Destination = 1,

		/// <summary>
		/// a third-party company is involving the delivery and customer is responsible for shipping costs
		/// </summary>
		[Description("Collect")]
		Collect = 2,

		/// <summary>
		/// varies by items/releases
		/// </summary>
		[Description("Variable")]
		Variable = 100 // the value 100 is never used and shouldn't used in database
	}
}
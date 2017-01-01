namespace Plasticonnect.Engine
{
	public partial class RfqItem : RequisitionItem
	{
		public enum QuantityRequested
		{
			/// <summary>
			/// Indicates that the quantity requested is exact number
			/// </summary>
			Exact,

			/// <summary>
			/// Asked for the best price. seller decides the quantity and put it in the quote
			/// </summary>
			BestPrice,

			/// <summary>
			/// Asked for the minimum possible quantity. sellers decides the quantity and put it in the quote
			/// </summary>
			MinimumQuantity
		}
	}
}

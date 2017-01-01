using System.ComponentModel.DataAnnotations;

namespace Plasticore
{
	[Table("RequisitionItem_RfqItems")]
	public partial class RfqItem : RequisitionItem
	{
		public enum QuantityRequested
		{
			/// <summary>
			/// Indicates that the quantity requested is exact number
			/// </summary>
			Exact,

			/// <summary>
			/// Asked for the minimum possible quantity. sellers decides the quantity and put it in the quote
			/// </summary>
			MinimumQuantity
		}

		public string DelMe { get; set; }


		public Condition AddCondition(string condition)
		{
			return AddCondition(Condition.AuthorType.Buyer, condition);
		}
	}
}

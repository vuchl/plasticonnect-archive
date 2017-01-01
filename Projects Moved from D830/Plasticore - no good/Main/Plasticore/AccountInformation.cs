using Plasticonnect;

namespace Plasticore
{
	public class AccountInformation
	{
		public string AccountNumber { get; set; }
		public Address BillingAddress { get; set; }
		public Contact Buyer { get; set; }

		public Currency DefaultCurrency { get; set; }
	}
}
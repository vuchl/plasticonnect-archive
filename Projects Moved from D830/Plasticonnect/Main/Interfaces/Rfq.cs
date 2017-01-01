using System;
using System.Collections.Generic;

namespace Plasticonnect.Engine
{
	public partial class Rfq : Requisition
	{
		/// <summary>
		/// The major none-modifiable number indicating an account. This is the connection
		/// between the current system and the Account Management system or CRM.
		/// </summary>
		public string AccountNumber { get; set; }

		/// <summary>
		/// Stores the account information by the time of submitting the RFQ
		/// </summary>
		public AccountInformation BillingTo { get; set; }

		/// <summary>
		/// Requested Payment Terms; can be overrided by seller in the Quote
		/// </summary>
		public PaymentTerms RequestedPaymentTerms { get; set; }

		public override List<Engine.RequisitionItem> Items { get; set; }

		/// <summary>
		/// Althogh the delivery is assigned in the requisition-item level, this methods
		/// helps to overwrite every items with the same value
		/// </summary>
		/// <param name="newPostalCode">The postal code that should be overwriten to all items</param>
		public void SetDeliveryPostalCode(string newPostalCode)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// returns a string indicating the FOB of the RFQ
		/// </summary>
		public string GetDeliveryFob()
		{
			// can return one of the followings:
			// Variable
			// SellerWarehouse
			// Destination
			throw new NotImplementedException();
		}

		/// <summary>
		/// returns a string indicating the FOB of the RFQ
		/// </summary>
		public string GetDeliveryAddress()
		{
			// can return one of the followings:
			// Variable
			// Ship-To address.ToString()
			throw new NotImplementedException();
		}
	}

	public class RegisteredRfq : Rfq
	{
		/// <summary>
		/// RFQ ID
		/// </summary>
		public string ReferenceNumber { get; set; }

		/// <summary>
		/// Date and Time that RFQ submitted to the system
		/// </summary>
		public DateTime SubmittedDate { get; set; }

	}
}
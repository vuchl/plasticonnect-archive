using System;
using System.Collections.Generic;
using System.Linq;

namespace Plasticore
{
	public abstract class Requisition
	{
		//todo: Hamed, I have removed the usage of Requisition. However I think we need to keep the following shared method somewhere!

		public bool IsMultipleDelivery
		{
			get { return HasMultipleFob || HasMultipleRequestedDeliveryDate || HasMultipleShipToAddress; }
		}

		public bool HasMultipleFob
		{
			get
			{
				if (IsEmpty || IsSingleItem) return false;
				var fob = Items[0].Delivery.Fob;
				return Items.Any(item => fob != item.Delivery.Fob);
			}
		}

		public bool HasMultipleRequestedDeliveryDate
		{
			get
			{
				if (IsEmpty || IsSingleItem) return false;
				var date = Items[0].Delivery.RequestedDeliveryDate;
				return Items.Any(item => date != item.Delivery.RequestedDeliveryDate);
			}
		}

		public bool HasMultipleShipToAddress
		{
			get
			{
				if (IsEmpty || IsSingleItem) return false;
				var address = Items[0].Delivery.Destination.PostalCode;
				return Items.Any(item => address != item.Delivery.Destination.PostalCode);
			}
		}

		public RequisitionItem FirstItem
		{
			get
			{
				if (IsEmpty)
					return null;
				return Items[0];
			}
		}

		public RequisitionItem LastItem
		{
			get
			{
				if (IsEmpty)
					return null;
				return Items[Count - 1];
			}
		}

		public int Count
		{
			get { return Items.Count; }
		}

		public bool IsEmpty
		{
			get { return Items.Count == 0; }
		}

		public bool IsSingleItem
		{
			get { return Items.Count == 1; }
		}

		public abstract List<RequisitionItem> Items { get; set; }

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
		public Payment Payment { get; set; }

		public string AdditionalComments { get; set; }

		public string GetDeliveryString()
			//todo: this is a UI method and has to be moved to the higher layers. however, I put it for illustration of the way it works
		{
			if (IsEmpty)
				return "No Item added to the requisition";

			var dateString = HasMultipleRequestedDeliveryDate
			                 	? "Requested dates vary per item"
			                 	: string.Format("All items required to be delivered on {0}",
			                 	                FirstItem.Delivery.RequestedDeliveryDate);

			var fobString = HasMultipleFob ? "FOB varies per item" : string.Format("FOB: {0}", FirstItem.Delivery.Fob);
			var postalCodeString = HasMultipleShipToAddress
			                       	? "Destination varies per item"
			                       	: string.Format("All items will be shipped to {0}",
			                       	                FirstItem.Delivery.Destination);

			return string.Format("{0}\n{1}\n{2}", dateString, fobString,
			                     FirstItem.Delivery.Fob == Fob.Pickup ? "" : postalCodeString);
		}
	}
}
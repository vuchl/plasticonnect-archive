using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Plasticonnect;

namespace Plasticore
{
	[Table("Requisitions")]
	public abstract class Requisition
	{
		public int Id { get; set; }

		public bool IsMultipleDelivery
		{
			get { return HasMultipleFob || HasMultipleRequestedDeliveryDate || HasMultipleShipToAddress; }
		}

		public bool HasMultipleFob
		{
			get
			{
				if (IsEmpty || IsSingleItem) return false;
				var fob = ItemList[0].Delivery.Fob;
				return ItemList.Any(item => fob != item.Delivery.Fob);
			}
		}

		public bool HasMultipleRequestedDeliveryDate
		{
			get
			{
				if (IsEmpty || IsSingleItem) return false;
				var date = ItemList[0].Delivery.RequestedDeliveryDate;
				return ItemList.Any(item => date != item.Delivery.RequestedDeliveryDate);
			}
		}

		public bool HasMultipleShipToAddress
		{
			get
			{
				if (IsEmpty || IsSingleItem) return false;
				var address = ItemList[0].Delivery.Destination.PostalCode;
				return ItemList.Any(item => address != item.Delivery.Destination.PostalCode);
			}
		}

		public RequisitionItem FirstItem
		{
			get
			{
				if (IsEmpty)
					return null;
				return ItemList[0];
			}
		}

		public RequisitionItem LastItem
		{
			get
			{
				if (IsEmpty)
					return null;
				return ItemList[Count - 1];
			}
		}

		public int Count
		{
			get { return ItemList.Count; }
		}

		public bool IsEmpty
		{
			get { return ItemList.Count == 0; }
		}

		public bool IsSingleItem
		{
			get { return ItemList.Count == 1; }
		}

		public virtual List<RequisitionItem> ItemList { get; set; }

//		/// <summary>
//		/// Requested Payment Terms; can be overrided by seller in the Quote
//		/// </summary>
//		public Payment Payment { get; set; }

		public string AdditionalComments { get; set; }

#region Account information by the time of submitting the RFQ

		/// <summary>
		/// The major none-modifiable number indicating an account. This is the connection
		/// between the current system and the Account Management system or CRM.
		/// </summary>
		public string AccountNumber { get; set; }

		[Required]
		public string CustomerName { get; set; }

		[Required]
		public Address BillingAddress { get; set; }

		[Required]
		public Currency RequestedCurrency { get; set; }

		public string BuyerContact { get; set; }

#endregion

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
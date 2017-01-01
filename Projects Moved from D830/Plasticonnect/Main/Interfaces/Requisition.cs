using System.Collections.Generic;
using System.Linq;

namespace Plasticonnect.Engine
{
	public abstract class Requisition
	{
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
			get { return Items[0]; }
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
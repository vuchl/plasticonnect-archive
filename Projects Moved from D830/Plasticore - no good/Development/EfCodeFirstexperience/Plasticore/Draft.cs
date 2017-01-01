using System;
using System.Collections.Generic;

namespace Plasticore
{
	public partial class Draft
	{
//		public override List<RequisitionItem> Items { get; set; }

		/// <summary>
		/// Indicates that RFQ is open and customer accepting quotes;
		/// </summary>
		public DateTime Deadline { get; set; }

		/// <summary>
		/// Adds a new draft item to the items list and return its reference
		/// </summary>
		public RequisitionItem AddItem(Product product)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Copies the last item into a new item and adds it to the list. 
		/// </summary>
		/// <returns></returns>
		public DraftItem RepeatLast()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Althogh the delivery is assigned in the requisition-item level, this methods
		/// helps to overwrite every items with the same value
		/// </summary>
		public void SetDeliveryToDestination(string postalCode, DateTime requestedDeliveryDate)
		{
			foreach (DraftItem item in Items)
			{
				item.SetDeliveryToDestination(postalCode, requestedDeliveryDate);
			}
		}

		/// <summary>
		/// Althogh the delivery is assigned in the requisition-item level, this methods
		/// helps to overwrite every items with the same value
		/// </summary>
		public void SetDeliveryToPickup(DateTime requestedDeliveryDate)
		{
			foreach (DraftItem item in Items)
			{
				item.SetDeliveryToPickup(requestedDeliveryDate);
			}
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
}
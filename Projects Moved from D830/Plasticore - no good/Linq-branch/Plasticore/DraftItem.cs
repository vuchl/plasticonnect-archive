using System;

namespace Plasticore
{
	public class DraftItem : RequisitionItem
	{
		/// <summary>
		/// Move the item one up closer to the top of the list of the parent requisition items
		/// </summary>
		public void MoveUp()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Move the item one down closer to the end of the list of the parent requisition items
		/// </summary>
		public void MoveDown()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Deletes the item form the list of the parent requisition items
		/// </summary>
		public void Delete()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Repeats the item in the list of parent requisition items and place it right after the current. 
		/// <returns>The newly created item</returns>
		/// </summary>
		public DraftItem Repeat()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Sets the delivery to pickup and sets the requested delivery date
		/// </summary>
		/// <remarks>
		/// <para>FOB and Postal Code of the delivery options for a draft item should be set, however the rest of the delivery information could be set
		/// when an order is in placed.</para>
		/// <para>The <see cref="Draft.SetDeliveryToDestination"/> method is used to replace all the items of the draft at the same time</para> 
		/// </remarks>
		public void SetDeliveryToPickup(DateTime requestedDeliveryDate)
		{
			Delivery.Fob = Fob.Pickup;

			Delivery.Destination.PostalCode = "";
			Delivery.RequestedDeliveryDate = requestedDeliveryDate;
		}

		/// <summary>
		/// Sets the delivery to Destination and sets the postal code and requested delivery date
		/// </summary>
		/// <remarks>
		/// <para>FOB and Postal Code of the delivery options for a draft item should be set, however the rest of the delivery information could be set
		/// when an order is in placed.</para>
		/// <para>The <see cref="Draft.SetDeliveryToDestination"/> method is used to replace all the items of the draft at the same time</para> 
		/// </remarks>
		public void SetDeliveryToDestination(string postalCode, DateTime requestedDeliveryDate)
		{
			Delivery.Fob = Fob.Destination;

			Delivery.Destination.PostalCode = postalCode;
			Delivery.RequestedDeliveryDate = requestedDeliveryDate;
		}

		/// <summary>
		/// Adds a new quantity to the list of quantities
		/// </summary>
		public void AddQuantitity(int figure)
		{
			AddQuantitites(QuantityMatrix.QuantityType.Requested, figure, 0m);
		}
	}
}

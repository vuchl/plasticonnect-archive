using System;

namespace Plasticore
{
	public class QuoteItem : RequisitionItem
	{
		/// <summary>
		/// Seller is able to set a new delivery date. This is the date that seller can 
		/// deliver the goods regardless of asking delivery date.
		/// </summary>
		public DateTime OfferedDeliveryDate { get; set; }

		/// <summary>
		/// Adds a new quantity to the list of quantities
		/// </summary>
		public void AddQuantitity(int figure, decimal price)
		{
			AddQuantitites(ItemQuantity.QuantityType.Offered, figure, price);
		}

		/// <summary>
		/// Remove any existing quantity from the quantity matrix; doesn't do anything if the quantity is not present in the matrix
		/// </summary>
		public void RemoveQuantity(int figure)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Adds a seller condition to the item;
		/// </summary>
		public void AddCondidtion(string condition)
		{
			throw new NotImplementedException();
		}

		//todo: Hamed, Consider removing a condition (seller condition)
	}
}

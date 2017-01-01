using System;
using System.Collections.Generic;
using Plasticonnect;

namespace Plasticore
{
	public abstract class RequisitionItem
	{
	    /// <summary>
		/// Different quantities for the item that can be asked by buyer or offered by seller
		/// </summary>
		public List<QuantityMatrix> Quantities { get; set; }
		public Product Product{ get; set; }
		public Uom Uom { get; set; }

		public DeliveryInformation Delivery { get; set; }

		private readonly List<Condition> _conditions = new List<Condition>();

		/// <summary>
		/// item specific conditions
		/// </summary>
		public List<Condition> Conditions { get { return _conditions; } }

		protected Condition AddCondition(Condition.AuthorType author, string comments)
		{
			var condition = new Condition {Author = author, Description = comments, Accepted = true};
			Conditions.Add(condition);
			return condition;
		}

		protected void AddQuantitites(QuantityMatrix.QuantityType quantityType, int figure, decimal price)
		{
			var qty = Quantities.Find(q => q.Figure == figure);
			if (qty != null)
			{
				qty.Price = price;
				return; 
			}

			var quantity = new QuantityMatrix {QauntityType = quantityType, Figure = figure, Price = price};
			Quantities.Add(quantity);
		}

		protected void RemoveQuantity(int figure)
		{
			var quantity = Quantities.Find(q => q.Figure == figure);
			if (quantity != null)
				Quantities.Remove(quantity);
		}

		/// <summary>
		/// Removes any existing quantity and sets the item as the minimum quantity requested
		/// </summary>
		public void ResetToMinimumQuantity()
		{
			Quantities.Clear();
		}

		/// <summary>
		/// Indicates if no quantity has been assigned to the item and it is going for the minumum quantity
		/// </summary>
		public bool IsMinumumQuantity
		{
			get { return Quantities.Count == 0; }
		}

		/// <summary>
		/// Indicates if the item has only one release
		/// </summary>
		public bool IsSingleRelease
		{
			get { return !IsMultipleRelease; }
		}

		/// <summary>
		/// Indicates if the item has more than one release
		/// </summary>
		public bool IsMultipleRelease
		{
			get { throw new NotImplementedException(); }
		}

		/// <summary>
		/// keeps the maximum period of releases for the multiple-release items
		/// </summary>
		public ReleasePeriod ReleasePeriod { get; set; }

		/// <summary>
		/// number of releases of the items. it is alway 1 for the single release items
		/// </summary>
		public int NumberOfReleases { get; set; }
	}

    /// <summary>
    /// Additional condition that can be added to an item
    /// </summary>
    public partial class Condition
    {
        public enum AuthorType {Buyer, Seller}

        /// <summary>
        /// Shows who added the comments
        /// </summary>
        public AuthorType Author { get; set; }

        /// <summary>
        /// Describes the condition
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Indicates if the condition is accepted by the other party
        /// </summary>
        public bool Accepted { get; set; }
    }
}

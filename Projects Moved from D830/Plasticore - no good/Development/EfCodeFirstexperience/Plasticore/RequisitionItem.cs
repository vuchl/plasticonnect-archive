using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Plasticonnect;

namespace Plasticore
{
	public abstract class RequisitionItem
	{
		#region Data Members

		public int Id { get; set; }

		/// <summary>
		/// Different quantities for the item that can be asked by buyer or offered by seller
		/// </summary>
		public virtual List<ItemQuantity> QuantityMatrix { get; set; }
		public Product Product{ get; set; }

		public Uom Uom
		{
			get { return (Uom) EnumHelper_Uom; }
			set { EnumHelper_Uom = (int) value; }
		}

		[Column("Uom")]
		public int EnumHelper_Uom { get; internal set; }

		public DeliveryInformation Delivery { get; set; }

		/// <summary>
		/// item specific conditions
		/// </summary>
		public List<Condition> Conditions { get; set; }

		/// <summary>
		/// keeps the maximum period of releases for the multiple-release items
		/// </summary>
		public ReleasePeriod ReleasePeriod { get; set; }

		/// <summary>
		/// number of releases of the items. it is alway 1 for the single release items
		/// </summary>
		public int NumberOfReleases { get; set; }

		#endregion

		protected Condition AddCondition(Condition.AuthorType author, string comments)
		{
			var condition = new Condition {Author = author, Description = comments, Accepted = true};
			Conditions.Add(condition);
			return condition;
		}

		protected void AddQuantitites(ItemQuantity.QuantityType quantityType, int figure, decimal price)
		{
			var qty = QuantityMatrix.Find(q => q.Figure == figure);
			if (qty != null)
			{
				qty.Price = price;
				return; 
			}

			var quantity = new ItemQuantity {QauntityType = quantityType, Figure = figure, Price = price};
			QuantityMatrix.Add(quantity);
		}

		protected void RemoveQuantity(int figure)
		{
			var quantity = QuantityMatrix.Find(q => q.Figure == figure);
			if (quantity != null)
				QuantityMatrix.Remove(quantity);
		}

		/// <summary>
		/// Removes any existing quantity and sets the item as the minimum quantity requested
		/// </summary>
		public void ResetToMinimumQuantity()
		{
			QuantityMatrix.Clear();
		}

		/// <summary>
		/// Indicates if no quantity has been assigned to the item and it is going for the minumum quantity
		/// </summary>
		public bool IsMinumumQuantity
		{
			get { return QuantityMatrix.Count == 0; }
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
	}

	/// <summary>
	/// Additional condition that can be added to an item
	/// </summary>
	public class Condition
	{

		public int Id { get; set; }

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

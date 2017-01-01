using System;
using Common;
using DataProvider;
using Mapping;
using Regency;
using ROS.Schema.SchemaDraftItemTableAdapters;

namespace ROS.Schema {
	public partial class SchemaDraftItem
	{
		partial class DraftItemsRow: IRequisitionItemDataProvider
		{
			public int DataId { get { return ID; } }

			/// <summary>
			/// ID of the equivalent of this requisitionItem in the old system's database (OrderDetailNumber)
			/// </summary>
			public int DataRegencyRefId
			{
				get { return RegencyRefID; }
				set { RegencyRefID = value; }
			}

			public int DataProductId
			{
				get { return ProductID; }
				set { ProductID = value; }
			}

			public IProductDataProvider DataProductDataProvider
			{
				get
				{
					return null;
				}
			}

			/// <summary>
			/// gets the default FOB of the item. <br />
			/// is used for new releases to be add.
			/// </summary>
			public FOB DataDefaultFob
			{
				get { return (FOB)defaultFob; }
				set { defaultFob = (int)value; }
			}

			/// <summary>
			/// gets the delivery type of the item
			/// </summary>
			public RequisitionItemDeliveryType DataDeliveryType
			{
				get { return (RequisitionItemDeliveryType)Blanket; }
				set { Blanket = (byte)value; }
			}

			/// <summary>
			/// Optional comments on RequisitionItems
			/// </summary>
			public string DataComments
			{
				get { return Comments; }
				set { Comments = value; }
			}

			/// <summary>
			/// gets the item serial number in the field of Requisition Items
			/// </summary>
			public byte DataItemOrdinal
			{
				get { return (byte) Sequence; }
				set { Sequence = value; }
			}

			/// <summary>
			/// Maximum date that a release of the item can be set
			/// </summary>
			public DateTime DataMaxReleaseDate
			{
				get { return MaxReleaseDate; }
				set { MaxReleaseDate = value; }
			}

			/// <summary>
			/// Unique id of the requisition that the item belongs to
			/// </summary>
			public int DataOwnerID
			{
				get { return Owner; }
				set { Owner = value; }
			}

			public int? DataParentItemId
			{
				get
				{
					object o = this[tableDraftItems.ParentItemIdColumn];
					if(o is DBNull)
						return null;

					return Convert.ToInt32(o);
				}
				set
				{
					this[tableDraftItems.ParentItemIdColumn] = (object) value ?? DBNull.Value;
				}
			}

			/// <summary>
			/// Optional notes about pricing
			/// </summary>
			public string DataPricingNote
			{
				get { return PricingNote; }
				set { PricingNote = value; }
			}

			/// <summary>
			/// Quantity of the product
			/// </summary>
			public int DataQuantity
			{
				get { return Quantity; }
				set { Quantity = value; }
			}

			/// <summary>
			/// gets unit price of the item
			/// </summary>
			public decimal DataUnitPrice
			{
				get { return UnitPrice; }
				set { UnitPrice = value; }
			}

			/// <summary>
			/// Unit of measurement
			/// </summary>
			public UOMType DataUom
			{
				get { return (UOMType)UOM; }
				set { UOM = (byte)value; }
			}

			/// <summary>
			/// applies all changes to the database
			/// </summary>
			public void Save()
			{
				DraftItemsTableAdapter adapter = new DraftItemsTableAdapter();
				adapter.Update(this);
			}

			public int DataShipToAddressId
			{
				get { return defaultDestination; }
				set { defaultDestination = value; }
			}
		}
	}
}

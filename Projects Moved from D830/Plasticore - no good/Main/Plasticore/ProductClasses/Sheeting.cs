using System.Collections.Generic;
using Plasticonnect;
using ValidationManager;

namespace Plasticore
{
	/// <summary>
	/// Represents a Sheeting product.
	/// </summary>
	public class Sheeting : Product, Roll, Flat
	{
		/// <summary>
		/// Unique ID of the product
		/// </summary>
		public int ProductId
		{
			get
			{
				return Id;
			}
		}

		/// <summary>
		/// Calculated Weight of the product
		/// </summary>
		public override decimal Weight
		{
			get
			{
				/* the width size of all folded good is the opened size
								 * however for the double wounded sheeting, this size
								 * is the width of each separate sheeting;
								 * therefore we need to double the volume if this is a 
								 * double wounded sheeting
								 */

				int wound = FoldingInfo.FoldType == FoldType.DoubleWoundSheeting ? 2 : 1;

				decimal area;
				if ((short)Packaging.Type == 3) //SqFtPerRoll is selected
					area = Packaging.Value * 144;
				else if ((short)Packaging.Type == 4) //LnFtPerRoll is selected
					area = Width * Packaging.Value * wound * 12;
				else //(which means Lb/Roll is selected)
					return Packaging.Value;

				decimal volume = area * Gauge.Size;
				return volume / 30;
			}
		}

		public override PackagingType[] GetValidPackages()
		{
			return ValidPackages;
		}

		public static readonly PackagingType[] ValidPackages = new[] { PackagingType.SqFtPerRoll, PackagingType.LnFtPerRoll, PackagingType.LbsPerRoll };



		/// <summary>
		/// Default UOM
		/// </summary>
		public override Uom DefaultUom
		{
			get { return Uom.Lbs; }
		}

		public FoldingInfo FoldingInfo
		{
			get
			{
				return Folding;
			}
		}

		/// <summary>
		/// A hashtable of all the valid UOMs that can be used for LooseBg
		/// </summary>
		public override List<Uom> ValidUoms
		{
			get
			{
				var newList = new List<Uom>(2) { Uom.Lbs, Uom.Rolls };
				return newList;
			}
		}

		// ------- Packaging Info ------------------
		/// <summary>
		/// Number of rolls on a skid
		/// </summary>
		public new short RollsPerSkid
		{
			get { return base.RollsPerSkid; }
			set { base.RollsPerSkid = value; }
		}

		#region Validation Rules
		// ReSharper disable UnusedMember.Local

		[ValidationRule("", "Product width should be a number between 4\" and 336\"")]
		private bool Rule1()
		{
			return Width >= 4m && Width <= 336m;
		}

		// ReSharper restore UnusedMember.Local
		#endregion
	}
}

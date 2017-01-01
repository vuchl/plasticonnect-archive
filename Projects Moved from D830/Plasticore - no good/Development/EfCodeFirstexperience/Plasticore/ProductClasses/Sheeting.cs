using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Plasticonnect;
using ValidationManager;

namespace Plasticore
{
	/// <summary>
	/// Represents a Sheeting product.
	/// </summary>
	[Table("Product_Sheetings")]
	public class Sheeting : Product, Roll, Flat
	{
		#region Data Members

		public FoldingInfo FoldingInfo { get; set; }

		#endregion

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
				switch (Packaging.Type)
				{
					case PackagingType.SqFtPerRoll:
						area = Packaging.Value * 144;
						break;
					case PackagingType.LnFtPerRoll:
						area = Width * Packaging.Value * wound * 12;
						break;
					default:
						return Packaging.Value;
				}

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

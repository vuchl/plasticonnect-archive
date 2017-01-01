using System.Collections.Generic;
using Plasticonnect;
using ValidationManager;

namespace Plasticore
{
	/// <summary>
	/// Represents a PTOSheet product.
	/// </summary>
	public class PtoSheet : Product, Roll, Pto, Flat
	{

		#region Public Properties

		/// <summary>
		/// Default UOM
		/// </summary>
		public override Uom DefaultUom
		{
			get { return Uom.M1000; }
		}

		public FoldingInfo FoldingInfo
		{
			get
			{
				return Folding;
			}
		}

		/// <summary>
		/// Length of the product
		/// </summary>
		public new decimal Length
		{
			get { return base.Length; }
			set { base.Length = value; }
		}

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
		/// Number of rolls on a skid
		/// </summary>
		public new short RollsPerSkid
		{
			get { return base.RollsPerSkid; }
			set { base.RollsPerSkid = value; }
		}

		/// <summary>
		/// A hashtable of all the valid UOMs that can be used for LooseBg
		/// </summary>
		public override List<Uom> ValidUoms
		{
			get
			{
				var newList = new List<Uom>(3) { Uom.Lbs, Uom.Rolls, Uom.M1000 };
				return newList;
			}
		}

		/// <summary>
		/// Calculated Weight of the product
		/// </summary>
		public override decimal Weight
		{
			get
			{
				decimal area = Width * Length;
				decimal volume = area * Gauge.Size;
				return volume / 30;
			}
		}

		public static readonly PackagingType[] ValidPackages = new[] { PackagingType.LbsPerRoll, PackagingType.QtyPerRoll };

		public override PackagingType[] GetValidPackages()
		{
				return ValidPackages;
		}

		// ------- Packaging Info ------------------


		#endregion

		#region Validation Rules
		// ReSharper disable UnusedMember.Local

		[ValidationRule("", "Product width should be a number between 10\" and 1000\"")]
		private bool Rule1()
		{
			return Width >= 10m && Width <= 1000m;
		}

		[ValidationRule("", "Product length has to be a number between 10\" and 1000\"")]
		private bool Rule2()
		{
			return Length >= 10m && Length <= 1000m;
		}

		// ReSharper restore UnusedMember.Local
		#endregion
	}
}

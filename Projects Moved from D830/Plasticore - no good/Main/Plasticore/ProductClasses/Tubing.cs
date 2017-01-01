using System.Collections.Generic;
using Plasticonnect;
using ValidationManager;

namespace Plasticore
{
	/// <summary>
	/// Represents a Tubing product.
	/// </summary>
	public class Tubing : Product, Roll, IGussetable
	{
		#region Public Properties

		/// <summary>
		/// Default UOM
		/// </summary>
		public override Uom DefaultUom
		{
			get { return Uom.Lbs; }
		}

		/// <summary>
		/// Represents all the properties that are involved in gusset definition
		/// Refer to Gusset class for more detail
		/// </summary>
		public new Gusset Gusset
		{
			get { return base.Gusset; }
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
				var newList = new List<Uom>(2) { Uom.Lbs, Uom.Rolls };
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
				decimal area;
				if ((short)Packaging.Type == 4) //LnFt per Roll is selected
					area = (Width + Gusset.Size) * Packaging.Value * 2 * 12;
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

		public static readonly PackagingType[] ValidPackages = new[] { PackagingType.LnFtPerRoll, PackagingType.LbsPerRoll };

		// ------- Packaging Info ------------------


		#endregion

		#region Validation Rules
		// ReSharper disable UnusedMember.Local

		[ValidationRule("", "Tubing width should be a number between 4\" and 150\"")]
		private bool Rule1()
		{
			return (Width >= 4m && Width <= 150m);
		}

		// ReSharper restore UnusedMember.Local
		#endregion
	}
}

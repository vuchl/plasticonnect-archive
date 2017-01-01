using System;
using System.Collections.Generic;
using ValidationManager;

namespace Plasticonnect.Engine
{
	/// <summary>
	/// Represents a CGP product.
	/// </summary>
	public class Cgp : Product, Flat, Roll
	{

		#region Public Properties

		/// <summary>
		/// Default UOM
		/// </summary>
		public override Uom DefaultUom
		{
			get { return Uom.Rolls; }
		}

		public FoldingInfo FoldingInfo
		{
			get { return Folding; }
		}

		/// <summary>
		/// Length of CGP product
		/// </summary>
		public new decimal Length
		{
			get { return base.Length; }
			set { base.Length = value; }
		}

		/// <summary>
		/// Unique ID of CGP product
		/// </summary>
		public int ProductId
		{
			get
			{
				return Id;
			}
		}

		/// <summary>
		/// Number of rolls per skid
		/// </summary>
		public new short RollsPerSkid
		{
			get { return base.RollsPerSkid; }
			set { base.RollsPerSkid = value; }
		}

		/// <summary>
		/// Square footage of the product per roll
		/// </summary>
		public decimal Sqft
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

				switch (Packaging.Type)
				{
					case PackagingType.SqFtPerRoll:
						return Packaging.Value;
					case PackagingType.LnFtPerRoll:

						return Math.Round(Packaging.Value * Width * wound / 144);
					default:
						return Math.Ceiling(Width * Length / 144);
				}
			}
		}

		/// <summary>
		/// Thickness of CGP
		/// </summary>
		public Thickness Thickness
		{
			get
			{
				decimal gaugevalue = Math.Abs(Gauge.Size);
				return Gauge.ConvertToThickness(gaugevalue);
			}
			set
			{
				Gauge.Size = Gauge.ConvertToDecimal(value);
				Gauge.FullGauge = true;
			}
		}

		/// <summary>
		/// A hash-table of all the valid UOMs that can be used for CGP
		/// </summary>
		public override List<Uom> ValidUoms
		{
			get
			{
				var newList = new List<Uom>(1) { Uom.Rolls };
				return newList;
			}
		}

		/// <summary>
		/// Calculated Weight of CGP product
		/// </summary>
		public override decimal Weight
		{
			get
			{
				decimal area = Sqft * 144;
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
		/// applies the changes to the database
		/// </summary>
		public new void Save()
		{
			// updating the Length based on the sqft value
			if (Width != 0)
				Length = Sqft * 144 / Width;
			else
				Length = 0;

			base.Save();
		}

		/// <summary>
		/// applies the changes to the database with assigning a part number
		/// </summary>
		public new void Save(string newPartNumber)
		{
			// updating the Length based on the sqft value
			if (Width != 0)
				Length = Sqft * 144 / Width;
			else
				Length = 0;

			base.Save(newPartNumber);
		}

		#endregion

		#region Validation Rules
		// ReSharper disable UnusedMember.Local

		[ValidationRule("", "Either SqFtPerRoll or LnFtPerRoll should be indicated")]
		private bool Rule1()
		{
			return Sqft > 0m;
		}

		// ReSharper restore UnusedMember.Local
		#endregion
	}
}

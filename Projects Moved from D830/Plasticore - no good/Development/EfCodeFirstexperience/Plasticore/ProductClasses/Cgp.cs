using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Plasticonnect;
using ValidationManager;

namespace Plasticore
{
	/// <summary>
	/// Represents a CGP product.
	/// </summary>
	[Table("Product_Cgps")]
	public class Cgp : Product, Flat, Roll
	{
		#region Data Members

		/// <summary>
		/// Square footage of a role of the product
		/// </summary>
		public int Sqft { get; set; }

		public FoldingInfo FoldingInfo { get; set; }

		#endregion

		/// <summary>
		/// Default UOM
		/// </summary>
		public override Uom DefaultUom
		{
			get { return Uom.Rolls; }
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

		public static readonly PackagingType[] ValidPackages = new[] { PackagingType.SqFtPerRoll };

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

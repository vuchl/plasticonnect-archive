using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Plasticonnect;
using ValidationManager;

namespace Plasticore
{
	/// <summary>
	/// Represents a PTOSleeve product.
	/// </summary>
	[Table("Product_PtoSleeves")]
	public class PtoSleeve : Product, Roll, Pto, IGussetable
	{
		#region Data Members

		/// <summary>
		/// Represents all the properties that are involved in gusset definition
		/// Refer to Gusset class for more detail
		/// </summary>
		public Gusset Gusset { get; set; }

		/// <summary>
		/// Length of the product
		/// </summary>
		public decimal Length { get; set; }

		#endregion

		/// <summary>
		/// Calculated Weight of the product
		/// </summary>
		public override decimal Weight
		{
			get
			{
				decimal area = (Width + Gusset.Size) * Length * 2;
				decimal volume = area * Gauge.Size;
				return volume / 30;
			}
		}

		public override PackagingType[] GetValidPackages()
		{
			return ValidPackages;
		}

		public static readonly PackagingType[] ValidPackages = new[] { PackagingType.LbsPerRoll, PackagingType.QtyPerRoll };


		/// <summary>
		/// Default UOM
		/// </summary>
		public override Uom DefaultUom
		{
			get { return Uom.M1000; }
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

		#region Validation Rules
		// ReSharper disable UnusedMember.Local

		[ValidationRule("", "Product less than 150\"")]
		private bool Rule1()
		{
			return (Width <= 150);
		}

		[ValidationRule("", "Product Length has to be a number between 2\" and 500\"")]
		private bool Rule2()
		{
			return (Length <= 500 && Length >= 2);
		}

		// ReSharper restore UnusedMember.Local
		#endregion
	}
}

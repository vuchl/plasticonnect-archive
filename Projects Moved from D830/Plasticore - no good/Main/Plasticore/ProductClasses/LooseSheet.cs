using System.Collections.Generic;
using Plasticonnect;
using ValidationManager;

namespace Plasticore
{
	/// <summary>
	/// Represents a LooseSheet product
	/// </summary>
	public class LooseSheet : Product, Loose
	{
		#region Privates

		/// <summary>
		/// Default UOM
		/// </summary>
		public override Uom DefaultUom
		{
			get { return Uom.M1000; }
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
		/// A hashtable of all the valid UOMs that can be used for LooseBg
		/// </summary>
		public override List<Uom> ValidUoms
		{
			get
			{
				var newList = new List<Uom>(2) { Uom.M1000, Uom.Cartons };
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

		public override PackagingType[] GetValidPackages()
		{
			return ValidPackages;
		}

		public static readonly PackagingType[] ValidPackages = new[] { PackagingType.LbsPerCarton, PackagingType.QtyPerCarton };


		#endregion

		#region Validation Rules
		// ReSharper disable UnusedMember.Local

		[ValidationRule("", "Product length and width could not be greater than 98\" at the same time.")]
		private bool Rule1()
		{
			return (Length < 98m || Width < 98m);
		}

		[ValidationRule("", "Product length could not be less than 4\".")]
		private bool Rule2()
		{
			return (Length >= 4m);
		}

		// ReSharper restore UnusedMember.Local
		#endregion
	}
}

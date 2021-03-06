﻿using System.Collections.Generic;
using Plasticonnect;
using ValidationManager;

namespace Plasticore
{
	/// <summary>
	/// Represents a Perferated Tear Off Bag product.
	/// </summary>
	public class PtoBag : Product, Roll, Pto, Bag
	{
		public override PackagingType[] GetValidPackages()
		{
			return ValidPackages;
		}

		public static readonly PackagingType[] ValidPackages = new[] { PackagingType.LbsPerRoll, PackagingType.QtyPerRoll };

		/// <summary>
		/// Unique ID of the product
		/// </summary>
		public int ProductId
		{
			get { return Id; }
		}

		/// <summary>
		/// indicates if the LooseBag has Hood
		/// </summary>
		public bool HasHood
		{
			get { return LipHood.Type != HoodType.None; }
		}

		/// <summary>
		/// indicates if the LooseBag has Lip
		/// </summary>
		public bool HasLip
		{
			get { return LipHood.LipSize > 0; }
		}

		/// <summary>
		/// Calculated Weight of the product
		/// </summary>
		public override decimal Weight
		{
			get
			{
				decimal area;

				switch (Sealing)
				{
					case SealingType.Bottom:
						area = (Width + Gusset.Size) * Length * 2;
						break;
					case SealingType.Side:
						area = Width * (Length * 2 + Gusset.Size + LipHood.LipSize + LipHood.HoodSize);
						break;
					default:
						area = 0m;
						break;
				}

				decimal volume = area * Gauge.Size;
				return volume / 30;
			}
		}

		// ------- Packaging Info ------------------

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
		/// Default UOM
		/// </summary>
		public override Uom DefaultUom
		{
			get { return Uom.M1000; }
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
		/// Represents all the properties that are involved in gusset definition
		/// Refer to Gusset class for more detail
		/// </summary>
		public new Gusset Gusset
		{
			get { return base.Gusset; }
		}

		public new decimal Length
		{
			get { return base.Length; }
			set { base.Length = value; }
		}

		public new bool LeakProof
		{
			get { return base.LeakProof; }
			set { base.LeakProof = value; }
		}

		public new LipHood LipHood
		{
			get { return base.LipHood; }
		}

		/// <summary>
		/// Indicates whether the sealed end or open end should be seald first
		/// </summary>
		public new SealedFirstType SealedFirst
		{
			get { return base.SealedFirst; }
			set { base.SealedFirst = value; }
		}

		/// <summary>
		/// Indicates the type of sealing
		/// Refer to SealingType for possible options
		/// </summary>
		public SealingType Sealing { get; set; }


		#region Validation Rules
		// ReSharper disable UnusedMember.Local

		[ValidationRule("", "Product Length has to be a number between 12\" and 360\"")]
		private bool Rule1()
		{
			return Length >= 12 && Length <= 360;
		}

		[ValidationRule("", "Gusset-Size has to be less than or equal to Length when it is a Bottom-Gusset bag.")]
		private bool Rule2()
		{
			return Gusset.Orientation != GussetOrientation.BottomGusset || Gusset.Size <= Length;
		}

		[ValidationRule("", "Gusset-Size has to be less than or equal toWidth when it is a Side-Gusset bag.")]
		private bool Rule3()
		{
			return Gusset.Orientation != GussetOrientation.SideGusset || Gusset.Size <= Width;
		}

		[ValidationRule("", "Bag has to be Bottom-Sealed if it is a Side-Gusset bag.")]
		private bool Rule4()
		{
			return Gusset.Orientation != GussetOrientation.SideGusset || Sealing != SealingType.Side;
		}

		[ValidationRule("", "Bag has to be Side-Sealed if it is a Bottom-Gusset bag.")]
		private bool Rule5()
		{
			return Gusset.Orientation != GussetOrientation.BottomGusset || Sealing != SealingType.Bottom;
		}

		[ValidationRule("", "Lip-Size should be less than length.")]
		private bool Rule6()
		{
			return !HasLip || LipHood.LipSize < Length;
		}

		[ValidationRule("", "Side-Gusset bags cannot have lip.")]
		private bool Rule7()
		{
			return Gusset.Orientation != GussetOrientation.SideGusset || !HasLip;
		}

		[ValidationRule("", "Bottom-Sealed Bags should have the width of between 8\" and 120\"")]
		private bool Rule8()
		{
			return Sealing != SealingType.Bottom || (Width >= 8m && Width <= 120m);
		}

		// ReSharper restore UnusedMember.Local
		#endregion
	}
}


using System.Collections.Generic;
using ValidationManager;

namespace Plasticore
{
	/// <summary>
	/// Represents a LooseBag product
	/// </summary>
	public class LooseBag : Product, Loose, Bag
	{
		private Bundle _bundle;

		#region Public Properties

	    internal LooseBag(DataAccessLayer.Product productData) : base(productData)
	    {
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
		/// Calculated Weight of the product
		/// </summary>
		public override decimal Weight
		{
			get
			{
				decimal area = 0m;

				if (Sealing == SealingType.Bottom)
					area = (Width + Gusset.Size) * Length * 2;

				if (Sealing == SealingType.Side)
					area = Width * ((Length + HeaderSize) * 2 + Gusset.Size + LipHood.HoodSize + LipHood.LipSize);

				decimal volume = area * Gauge.Size;
				return volume / 30;
			}
		}

		public override PackagingType[] GetValidPackages()
		{
			return ValidPackages;
		}

		public static readonly PackagingType[] ValidPackages = new[] { PackagingType.LbsPerCarton, PackagingType.QtyPerCarton };

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
				var newList = new List<Uom>(2) { Uom.M1000, Uom.Cartons };
				return newList;
			}
		}

		// ------- Packaging Info ------------------

		/// <summary>
		/// Represents all the properties that are involved in gusset definition
		/// Refer to Gusset class for more detail
		/// </summary>
		public new Gusset Gusset
		{
			get { return base.Gusset; }
		}

		public bool HasHood
		{
			get { return LipHood.Type != HoodType.None; }
		}

		public bool HasLip
		{
			get { return LipHood.LipSize > 0; }
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

		/// <summary>
		/// Indicates whether the product has lip or hood or not.
		/// For more detail refer to LipHood class
		/// </summary>
		public new LipHood LipHood
		{
			get { return base.LipHood; }
		}

		/// <summary>
		/// Indicates the type of sealing
		/// Refer to SealingType for possible options
		/// </summary>
		public SealingType Sealing { get; set; }

		/// <summary>
		/// Indicates the size of the Header
		/// </summary>
		public new decimal HeaderSize { get; set; }

		/// <summary>
		/// Represents the Bundle properties on the product (if any)
		/// Refer to Bundle class for more information
		/// </summary>
		public Bundle Bundle
		{
			get { return _bundle ?? (_bundle = new Bundle()); }
		}


		#endregion

		#region Validation Rules
		// ReSharper disable UnusedMember.Local

		[ValidationRule("", "Product Length has to be a number between 2.5\" and 360\"")]
		private bool Rule01()
		{
			return (Length >= 2.5m && Length <= 360m);
		}

		[ValidationRule("", "Gusset-Size has to be less than or equal to Length when it is a Bottom-Gusset bag.")]
		private bool Rule02()
		{
			return Gusset.Orientation != GussetOrientation.BottomGusset ||
				  Gusset.Size <= Length;
		}

		[ValidationRule("", "Gusset-Size has to be less than or equal to Width when it is a Side-Gusset bag.")]
		private bool Rule03()
		{
			return Gusset.Orientation != GussetOrientation.SideGusset ||
				  Gusset.Size <= Width;
		}

		[ValidationRule("", "Bag has to be Bottom-Sealed if it is a Side-Gusset bag.")]
		private bool Rule04()
		{
			return Gusset.Orientation != GussetOrientation.SideGusset ||
				  Sealing != SealingType.Side;
		}

		[ValidationRule("", "Bag has to be Side-Sealed if it is a Bottom-Gusset bag.")]
		private bool Rule05()
		{
			return Gusset.Orientation != GussetOrientation.BottomGusset ||
				  Sealing != SealingType.Bottom;
		}

		[ValidationRule("", "If bag is bottom-sealed the width should be between 2.625\" and 120\"")]
		private bool Rule06()
		{
			return Sealing != SealingType.Bottom ||
				  (Width >= 2.625m && Width <= 120m);
		}

		[ValidationRule("", "Lip-Size should be less than length.")]
		private bool Rule07()
		{
			return !HasLip || LipHood.LipSize < Length;
		}

		[ValidationRule("", "Side-Gusset bags cannot have lip.")]
		private bool Rule08()
		{
			return !HasLip || Gusset.Orientation != GussetOrientation.SideGusset;
		}

		[ValidationRule("", "Side-Gusset bags cannot have hood.")]
		private bool Rule09()
		{
			return !HasHood || Gusset.Orientation != GussetOrientation.SideGusset;
		}

		[ValidationRule("", "Lip Bags cannot be Bottom-Sealed")]
		private bool Rule10()
		{
			return !HasLip || Sealing == SealingType.Side;
		}

		[ValidationRule("", "Hood Bags cannot be Bottom-Sealed")]
		private bool Rule11()
		{
			return !HasHood || Sealing == SealingType.Side;
		}

		[ValidationRule("", "Hood-Size should be less than length.")]
		private bool Rule12()
		{
			return !HasHood || LipHood.HoodSize < Length;
		}

		[ValidationRule("", "Bag should be side-sealed, if it has a hood.")]
		private bool Rule13()
		{
			return !HasHood || Sealing == SealingType.Side;
		}

		private void AddValidationFunctions()
		{
/*
			addRules(LipHood);
*/
		}

		// ReSharper restore UnusedMember.Local
		#endregion
	}
}

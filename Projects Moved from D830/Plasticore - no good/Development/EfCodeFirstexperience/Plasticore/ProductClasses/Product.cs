using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Plasticonnect;
using ValidationManager;

namespace Plasticore
{
	/// <summary>
	/// Base of all Products
	/// </summary>
	public abstract class Product
	{
		#region Data Members

		/// <summary>
		/// Unique ID of the product
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Width of the product
		/// </summary>
		public decimal Width { get; set; }

		/// <summary>
		/// gauge of the product<br />
		/// Refer to <see cref="Gauge">Gauge</see> class for more detail
		/// </summary>
		public Gauge Gauge { get; set; }

		/// <summary>
		/// Optional name tag that can be given to the product. 
		/// If this has value in it the product would be treated as a predefined product
		/// </summary>
		public string PartNumber { get; set; }

		/// <summary>
		/// Indicates which slip type the product is of
		/// Refer to <see cref="SlipType"/> for the possible options
		/// </summary>
		public SlipType Slip
		{
			get { return (SlipType) EnumHelper_Slip; }
			set { EnumHelper_Slip = (int) value; }
		}

		[Column("SlipType")]
		public int EnumHelper_Slip { get; internal set; }

		/// <summary>
		/// Keeps information about the transparency and color of the product
		/// </summary>
		public ProductColor ProductColor { get; set; }

		/// <summary>
		/// Indicates different possibilities on packaging the product. 
		/// For example BagsPerCarton or LbsPerCarton
		/// Refer to options in order to get different possibilities for this property
		/// </summary>
		public Packaging Packaging { get; set; }

		/// <summary>
		/// Represents all the printing info related to this product
		/// </summary>	
		public Printing Printing { get; set; }

		/// <summary>
		/// chemical additives that can be added to the product
		/// </summary>
		public ChemicalAdditives ChemicalAdditives
		{
			get { return (ChemicalAdditives) EnumHelper_ChemicalAdditives; }
			set { EnumHelper_ChemicalAdditives = (int) value; }
		}

		[Column("ChemicalAdditivesBits")]
		public int EnumHelper_ChemicalAdditives { get; internal set; }

		/// <summary>
		/// gets/set number of months that Product can resist under the UVI
		/// </summary>
		public byte UviMonths { get; set; }

		public string ProductNotes { get; set; }

		#endregion

		/// <summary>
		/// gets the default UOM of the Product
		/// <seealso cref="ValidUoms"/>
		/// </summary>
		public abstract Uom DefaultUom { get; }

		/// <summary>
		/// indicates if the product has a gusset
		/// </summary>
		public bool HasGusset
		{
			get
			{
				if (this is IGussetable)
					return ((IGussetable)this).Gusset.Orientation != GussetOrientation.NoGusset;

				return false;
			}
		}

		/// <summary>
		/// indicates if the product has printing 
		/// </summary>
		public bool HasPrinting 
		{
			get { return Printing.Coloring != PrintingColoring.NoPrinting; }
		}

		/// <summary>
		/// Calculated net weight of the product.  <br />
		/// net weight is weight * 0.9 unless the product is a full gauge which in this condition net weight and weight are the same.
		/// </summary>
		/// <seealso cref="Weight"/>
		public decimal NetWeight
		{
			get
			{
				if (Gauge.FullGauge)
					return Weight;
				return Weight * 0.9m;
			}
		}

		/// <summary>
		/// gets the sizing signature of the product.
		/// </summary>
		/// <remarks>This is a method to compare similar products with their sizings.</remarks>
		public string Signature
		{
			get { return string.Format("{0}; {1}", "GetName()", "GetSizing()"); }
		}

		/// <summary>
		/// list of valid UOMs that can be used for ordering the Product
		/// <seealso cref="DefaultUom"/>
		/// </summary>
		public abstract List<Uom> ValidUoms { get; }

		/// <summary>
		/// returns the weigth of the product.
		/// <seealso cref="NetWeight"/>
		/// </summary>
		public abstract decimal Weight { get; }

		/// <summary>
		/// Gets a list of allowable PackagingType for the product; <br/>
		/// use when type is a parameter
		/// </summary>
		public abstract PackagingType[] GetValidPackages();

		///<summary>
		///</summary>
		///<param name="format"></param>
		///<returns></returns>
		public string ToString(string format)
		{
			return ToString();
		}

		#region Validation Rules
		// ReSharper disable UnusedMember.Local

		[ValidationRule("", "Composite rules failed")]
		private bool CompositeRules()
		{
			ValidatorEngine.Validate(ChemicalAdditives);
			ValidatorEngine.Validate(Gauge);
//			ValidatorEngine.Validate(Gusset);
			
			return false;
		}

		[ValidationRule("", "Shrink option is not applicable on products thinner than 1.5mil")]
		private bool Rule1()
		{
			return (((ChemicalAdditives & ChemicalAdditives.Shrink) == ChemicalAdditives.Shrink) || Gauge.Size >= .00125m);
		}

		[ValidationRule("", "Shrink option is not applicable on products thinner than 1.5mil")]
		private bool Rule2()
		{
			return (((ChemicalAdditives & ChemicalAdditives.Shrink) == ChemicalAdditives.Shrink) || Gauge.Size >= .00125m);
		}

		[ValidationRule("", "HighClarity option is not applicable on products thicker than or equal to 6mil")]
		private bool Rule3()
		{
			return (ProductColor.Transparency != TransparencyType.HighClarity || Gauge.Size < .006m);
		}

		[ValidationRule("", "HighClarity option is not applicable on products thicker than or equal to 6mil")]
		private bool Rule4()
		{
			return (ProductColor.Transparency != TransparencyType.HighClarity || Gauge.Size < .006m);
		}

		[ValidationRule("", "Color has to be defined for the Tint or Opaque transparency")]
		private bool Rule5()
		{
			return (ProductColor.Transparency == TransparencyType.RegularClarity ||
					ProductColor.Transparency == TransparencyType.HighClarity ||
					ProductColor.ResinColor != ResinColor.Clear);
		}

		[ValidationRule("", "clear transparency cannot have color")]
		private bool Rule6()
		{
			return (ProductColor.Transparency == TransparencyType.RegularClarity ||
					ProductColor.Transparency == TransparencyType.HighClarity ||
					ProductColor.ResinColor != ResinColor.Clear);
		}

		// ReSharper restore UnusedMember.Local
		#endregion
	}
}

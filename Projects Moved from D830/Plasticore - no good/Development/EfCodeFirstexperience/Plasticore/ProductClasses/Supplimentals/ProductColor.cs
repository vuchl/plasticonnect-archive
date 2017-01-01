using System.ComponentModel.DataAnnotations;
using Plasticonnect;

namespace Plasticore
{
	/// <summary>
	/// Contains all the information regarding color of a product.
	/// This class includes a <see cref="ResinColor"/> object that indicates the color of the product and 
	/// a <see cref="TransparencyType"/> object that provides the information regrading the transparency of the product color
	/// </summary>
	public class ProductColor
	{
		/// <summary>
		/// gets/sets the color of the product. This is the color that is used in blend to make a product colored.
		/// </summary>
		public ResinColor ResinColor
		{
			get { return (ResinColor)EnumHelper_ProductColor; }
			set { EnumHelper_ProductColor = (int) value; }
		}

		[Column("ProductColor_ResinColor")]
		public int EnumHelper_ProductColor { get; internal set; }

		/// <summary>
		/// gets/sets the Transparency level of the product
		/// </summary>
		public TransparencyType Transparency
		{
			get { return (TransparencyType)EnumHelper_TransparencyType; }
			set { EnumHelper_TransparencyType = (int)value; }
		}

		[Column("ProductColor_TransparencyType")]
		public int EnumHelper_TransparencyType { get; internal set; }

		/// <summary>
		/// overridden string format of the Color info
		/// </summary>
		public override string ToString()
		{
			switch (Transparency)
			{
				case TransparencyType.RegularClarity:
					return "Clear (Regular Clarity)";
				case TransparencyType.HighClarity:
					return "Clear (High Clarity)";
				default:
					{
						string colorDesc = RichEnum.GetDescription(ResinColor) ?? "Unspecified-Color";

						return string.Format("{0} {1}", RichEnum.GetDescription(Transparency), colorDesc);
					}
			}
		}
	}
}

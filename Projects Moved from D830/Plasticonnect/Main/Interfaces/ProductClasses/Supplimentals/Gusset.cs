using ValidationManager;

namespace Plasticonnect.Engine
{
	/// <summary>
	/// Keeps the gusset of a product. gusset can be applied on the side or the bottom of a product.
	/// </summary>
	public class Gusset
	{
		/// <summary>
		/// gets/set the orientation of the gusset. it could be side-gusset or bottom-gusset or no-gusset.
		/// notes: if you set the value of Orientation to no-gusset, the size will be change to 0.
		/// </summary>
		public GussetOrientation Orientation { get; set; }

		/// <summary>
		/// gets/sets the size of the Gusset 
		/// </summary>
		public decimal Size { get; set; }

		/// <summary>
		/// Returns a string that represents the gusset information in product description
		/// </summary>
		/// <returns>
		/// if gussetOrientation is not NoGusset and size is not zero then this will return:
		///		size(gussetOrientation), for example: 2.5(S) 
		/// </returns>
		public override string ToString()
		{
			if (Orientation == GussetOrientation.NoGusset || Size == 0)
				return "";
			//			string iorientation;
			//			iorientation = orientation == GussetOrientation.SideGusset ? "S" : "B";
			//			return size.ToString("#.####") + "(" + iorientation + ")";

			return string.Format("{0:#.####}({1})", Size, Orientation == GussetOrientation.SideGusset ? "S" : "B");
		}

		#region Validation Rules
		// ReSharper disable UnusedMember.Local

		[ValidationRule("", "Gusset Size should be less than or equal to Width")]
		private bool Rule1()
		{
			return false; // Size <= owner.Width;
		}

		[ValidationRule("", "Enter a valid size of gusset or change to No-Gusset")]
		private bool Rule2()
		{
			return Orientation == GussetOrientation.NoGusset || Size > 0.0m;
		}

		[ValidationRule("", "Gusset Orientation has to be selected if it has a size.")]
		private bool Rule3()
		{
			return Orientation == GussetOrientation.NoGusset || Size > 0.0m;
		}

		// ReSharper restore UnusedMember.Local
		#endregion
	}
}

using System.Collections.Generic;
using Plasticonnect;

namespace Plasticore
{
	/// <summary>
	/// Includes all the information on folding 
	/// </summary>
	public class FoldingInfo
	{
		/// <summary>
		/// Indicates the type of folding
		/// For possible values refer to <see cref="FoldType"/>
		/// </summary>
		public FoldType FoldType { get; set; }

		/// <summary>
		/// Indicates the position on the product that slitting should be applied
		/// </summary>
		public SlitPosition Slit { get; set; }

		/// <summary>
		/// Indicates whether the product should be trimmed or not
		/// </summary>
		public bool Trimmed { get; set; }

		public override string ToString()
		{
			var list = new List<string>();

			//if (FoldType != FoldType.Unknown)
			list.Add(RichEnum.GetDescription(FoldType));

			if (Slit != SlitPosition.RegencyDecides)
				list.Add(RichEnum.GetDescription(Slit));

			if (Trimmed)
				list.Add("Trimmed");

			return string.Join(", ", list.ToArray());

		}
	}
}

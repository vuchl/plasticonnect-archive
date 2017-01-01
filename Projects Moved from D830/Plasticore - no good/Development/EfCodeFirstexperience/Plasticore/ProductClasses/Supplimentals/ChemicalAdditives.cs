using System;
using ValidationManager;

namespace Plasticore
{
	/// <summary>
	/// Contains the chemical additives that can be used in making the product
	/// </summary>
	[Flags]
	public enum ChemicalAdditives
	{
		/// <summary>
		/// indicates if product is anti-block
		/// </summary>
		AntiBlock,

		/// <summary>
		/// indicates if product is anti-static
		/// </summary>
		AntiStatic ,

		/// <summary>
		/// indicates if product is food-flex
		/// </summary>
		FoodFlex ,

		/// <summary>
		/// indicates if product is Shrink
		/// </summary>
		Shrink,

		/// <summary>
		/// indicates if product uses virgin materials only
		/// </summary>
		VirginMaterial,

		/// <summary>
		/// indicates if product is high-impact
		/// </summary>
		HighImpact ,

		/// <summary>
		/// indicates if product is utility
		/// </summary>
		Utility,
	}
	
/*
	/// <summary>
	/// Contains the chemical additives that can be used in making the product
	/// </summary>
	public struct ChemicalAdditives
	{
		public int BitStream { get; internal set; }

		[ValidationRule("Usage", "Utility cannot be selected combined with other additives")]
		private bool MustHaveValidCombination()
		{
			return !((AntiBlock || AntiStatic || FoodFlex || Shrink || HighImpact) && Utility);
		}

		/// <summary>
		/// indicates if product is anti-block
		/// </summary>
		public bool AntiBlock { get; set; }

		/// <summary>
		/// indicates if product is anti-static
		/// </summary>
		public bool AntiStatic { get; set; }

		/// <summary>
		/// indicates if product is food-flex
		/// </summary>
		public bool FoodFlex { get; set; }

		/// <summary>
		/// indicates if product is Shrink
		/// </summary>
		public bool Shrink { get; set; }

		/// <summary>
		/// indicates if product uses virgin materials only
		/// </summary>
		public bool VirginMaterial { get; set; }

		/// <summary>
		/// indicates if product is high-impact
		/// </summary>
		public bool HighImpact { get; set; }

		/// <summary>
		/// indicates if product is utility
		/// </summary>
		public bool Utility { get; set; }

		/// <summary>
		/// string representation of chemical additives
		/// </summary>
		public override string ToString()
		{
			return ((AntiBlock) ? "Anti Block, " : "") +
				((AntiStatic) ? "Anti Static, " : "") +
				((FoodFlex) ? "Food Flex, " : "") +
				((Shrink) ? "Shrink, " : "") +
				((VirginMaterial) ? "Virgin Material, " : "") +
				((HighImpact) ? "High Impact, " : "") +
				((Utility) ? "Utility, " : "");
		}
	}
 */
}

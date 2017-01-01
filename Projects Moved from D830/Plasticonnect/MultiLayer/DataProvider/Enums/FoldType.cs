using System.ComponentModel;

namespace Plasticonnect.DataProvider.Enums
{
    /// <summary>
    /// FoldType class
    /// </summary>
    public enum FoldType
    {
		/// <summary>
		/// Fold-Type is not defined
		/// </summary>
        [Description("Not Specified")]
        Unknown = 0,

		/// <summary>
		/// one fold U form
		/// </summary>
        [Description("U-Film")]
        UFilm = 1,

		/// <summary>
		/// one fold J form (has a lip)
		/// </summary>
        [Description("J-Film")]
        JFilm = 2,

		/// <summary>
		/// two folds from the side going to thte center
		/// </summary>
        [Description("C-Film")]
        CFilm = 3,

		/// <summary>
		/// four folds (accardion)
		/// </summary>
        [Description("4-Fold")]
        FourFold = 4,

		/// <summary>
		/// No fold; single wound sheeting
		/// </summary>
        [Description("Single-Wounded Sheeting")]
        SingleWoundSheeting = 5,

		/// <summary>
		/// No fold; single wound sheeting
		/// </summary>
		[Description("Double-Wounded Sheeting")]
        DoubleWoundSheeting = 6
    }
}
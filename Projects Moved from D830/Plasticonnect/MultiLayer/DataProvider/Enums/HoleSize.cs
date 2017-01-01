using System.ComponentModel;

namespace Plasticonnect.DataProvider.Enums
{
    /// <summary>
    /// Defines the size of a hole
    /// </summary>
    public enum HoleSize
    {
		/// <summary>
		/// NoHoles
		/// </summary>
        [Description("NoHoles")]
        NoHoles = 0,

		/// <summary>
		/// One And a Half inches
		/// </summary>
        [Description(@"1.5""")]
        OneAndHalf = 1,

		/// <summary>
		/// Two inches
		/// </summary>
        [Description(@"2""")]
        Two = 2,

		/// <summary>
		/// C-Smile 1
		/// </summary>
        [Description("C-Smile-1")]
        CSmile1 = 3,

		/// <summary>
		/// C-Smile 2
		/// </summary>
        [Description("C-Smile-2")]
        CSmile2 = 4,

		/// <summary>
		/// 1/4 inches
		/// </summary>
        [Description(@"1/4""")]
        OneFourth = 5,
		
		/// <summary>
		/// 7/16 inches
		/// </summary>
        [Description(@"7/16""")]
        SevenSixteenth = 6,

		/// <summary>
		/// 1/8 inches
		/// </summary>
        [Description(@"1/8""")]
        OneEighth = 7,

		/// <summary>
		/// Half a inch
		/// </summary>
        [Description(@"1/2""")]
        OneSecond = 8,

		/// <summary>
		/// one inch
		/// </summary>
        [Description(@"1""")]
        One = 9,

		/// <summary>
		/// Hanger Hole
		/// </summary>
        [Description("Hanger Hole")]
        HangerHole = 10
    }
}
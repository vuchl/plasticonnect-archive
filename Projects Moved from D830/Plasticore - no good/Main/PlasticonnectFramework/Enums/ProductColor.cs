using System.ComponentModel;

namespace Plasticonnect
{
	/// <summary>
	/// Product Color; This is not same as Printing Color
	/// </summary>
	public enum ProductColor
	{
		/// <summary>
		/// Clear Film
		/// </summary>
		[Description("Clear")]
		Clear = 0,

		/// <summary>
		/// Yellow
		/// </summary>
		[Description("Yellow")]
		Yellow = 1,

		/// <summary>
		/// Blue
		/// </summary>
		[Description("Blue")]
		Blue = 2,

		/// <summary>
		/// Gray
		/// </summary>
		[Description("Gray")]
		Gray = 3,

		/// <summary>
		/// Green
		/// </summary>
		[Description("Green")]
		Green = 4,

		/// <summary>
		/// Orange
		/// </summary>
		[Description("Orange")]
		Orange = 5,

		/// <summary>
		/// Choclate Brown
		/// </summary>
		[Description("Choc. Brown")]
		ChocBrown = 6,

		/// <summary>
		/// Silver
		/// </summary>
		[Description("Silver")]
		Silver = 7,

		/// <summary>
		/// White
		/// </summary>
		[Description("White")]
		White = 8,

		/// <summary>
		/// Red
		/// </summary>
		[Description("Red")]
		Red = 9,

		/// <summary>
		/// Black
		/// </summary>
		[Description("Black")]
		Black = 10,

		/// <summary>
		/// Dark Blue
		/// </summary>
		[Description("Dark Blue")]
		DarkBlue = 11,


		/// <summary>
		/// Beige
		/// </summary>
		[Description("Beige")]
		Beige = 12,

		/// <summary>
		/// Purple
		/// </summary>
		[Description("Purple")]
		Purple = 13,

		/// <summary>
		/// Pink
		/// </summary>
		[Description("Pink")]
		Pink = 14,

		/// <summary>
		/// Charcoal Gray
		/// </summary>
		[Description("Charcoal Gray")]
		CharcoalGray = 15,

		/// <summary>
		/// Custom Color
		/// </summary>
		[Description("Match Sample")]
		MatchSample = 17,
	}
}

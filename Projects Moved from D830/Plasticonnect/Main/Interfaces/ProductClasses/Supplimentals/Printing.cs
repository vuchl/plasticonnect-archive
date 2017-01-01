namespace Plasticonnect.Engine
{
	/// <summary>
	/// Represents all the properties/functionality 
	/// that are related to printing on a product
	/// </summary>
	public class Printing
	{
		/// <summary>
		/// Indicates which sides should be printed on
		/// Refer to <see cref="PrintSideType"/> for possible choices
		/// </summary>
		public PrintSideType PrintSide { get; set; }

		/// <summary>
		/// First color of the printing ink
		/// </summary>
		/// <remarks>
		/// This has to be a limited number of color names or a pantone integer number
		/// </remarks>
		public string Color1 { get; set; }

		/// <summary>
		/// Second color of the printing ink 
		/// </summary>
		/// <remarks>
		/// This has to be a limited number of color names or a pantone integer number
		/// </remarks>
		public string Color2 { get; set; }

		/// <summary>
		/// Indicates the distance between each print in inches, if it is to be repeated. Otherwise leave 0.
		/// </summary>
		public decimal Repeat { get; set; }

		/// <summary>
		/// Indicates the text that should be printed and other comments about printing
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Indicates the direction of the text.
		/// Refer to <see cref="TextDirectionType"/> for the possible choices.
		/// </summary>
		public TextDirectionType TextDirection { get; set; }

		/// <summary>
		/// overridden string format of the object
		/// </summary>
		public override string ToString()
		{
			string retValue = "";
			string color = "";

			retValue += PrintSide + "; ";

			if (!string.IsNullOrEmpty(Color1))
			{
				color = Color1;
				if (!string.IsNullOrEmpty(Color2))
					color += " + ";
			}
			if (!string.IsNullOrEmpty(Color2))
			{
				color += Color2;
			}

			retValue += color == "" ? "" : (string.Format("[Color: {0}]; ", color));
			retValue += Repeat == 0.0m ? "" : (string.Format("repeats at every {0:#.####}\"; ", Repeat));
			retValue += Description == "" ? "" : ("[Printing Descriptions: " + Description + "]; ");
			retValue += TextDirection == TextDirectionType.Unknown ? "" : ("[Text Direction: " + TextDirection + "]; ");

			return retValue;
		}
	}
}

using System;
using Plasticonnect;
using ValidationManager;

namespace Plasticore
{
	/// <summary>
	/// Represents all the properties/functionality 
	/// that are related to printing on a product
	/// </summary>
	public struct Printing
	{
		/// <summary>
		/// Indicates the printing positioning
		/// </summary>
		public PrintingPositioning Positioning { get; set; }

		/// <summary>
		/// Indicates how is the printing on the outer side of the product (role outer side)
		/// </summary>
		public PrintingColoring OuterSide { get; set; }

		/// <summary>
		/// Indicates how is the printing on the inner side of the product (role inner side)
		/// </summary>
		public PrintingColoring InnerSide { get; set; }

		/// <summary>
		/// describes anything about printing that affects pricing
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// overridden string format of the object
		/// </summary>
		public override string ToString()
		{
			throw new NotImplementedException();

/*
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
*/
		}

		[ValidationRule("", "Digital Printing cannot be Random")]
		public bool Rule1()
		{
			return Positioning != PrintingPositioning.Random ||
			       (OuterSide != PrintingColoring.Digital && InnerSide != PrintingColoring.Digital);
		}
	}
}

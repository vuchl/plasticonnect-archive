using System;
using System.ComponentModel.DataAnnotations;
using Plasticonnect;
using ValidationManager;

namespace Plasticore
{
	/// <summary>
	/// Represents all the properties/functionality 
	/// that are related to printing on a product
	/// </summary>
	public class Printing
	{
		/// <summary>
		/// Indicates the type of printing
		/// </summary>
		public PrintingType Type 
		{
			get { return (PrintingType) EnumHelper_PrintingType; }
			set { EnumHelper_PrintingType = (int) value; }
		}

		[Column("Printing_Type")]
		public int EnumHelper_PrintingType { get; internal set; }

		/// <summary>
		/// Indicates number of colors applied to the product
		/// </summary>
		public PrintingColoring Coloring
		{
			get { return (PrintingColoring) EnumHelper_PrintingColoring; }
			set { EnumHelper_PrintingColoring = (int) value; }
		}

		[Column("Printing_Coloring")]
		public int EnumHelper_PrintingColoring { get; internal set; }

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
			return Type != PrintingType.Random || (Coloring != PrintingColoring.Digital);
		}
	}
}

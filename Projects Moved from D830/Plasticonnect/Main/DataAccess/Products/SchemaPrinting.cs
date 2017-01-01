using DataProvider;
using Products;
using Regency;
using ROS.Schema.SchemaPrintingTableAdapters;

namespace ROS.Schema {
	public partial class SchemaPrinting
	{
		partial class PrintingsRow : IPrintingDataProvider
		{
			#region IPrintingDataProvider Members

			public PrintSideType DataPrintSide
			{
				get { return (PrintSideType) Sides; }
				set { Sides = (int) value; }
			}

			public string DataColor1
			{
				get { return IsColor1Null() ? "" : Color1; }
				set { Color1 = value; }
			}

			public string DataColor2
			{
				get { return IsColor2Null() ? "" : Color2; }
				set { Color2 = value; }
			}

			public decimal DataRepeat
			{
				get { return IsRepeatNull() ? 0 : Repeat; }
				set { Repeat = value; }
			}

			public string DataText
			{
				get { return Comments; }
				set { Comments = value; }
			}

			public TextDirectionType DataTextDirection
			{
				get { return (TextDirectionType) Direction; }
				set { Direction = (int) value; }
			}

			public void Save()
			{
				PrintingsTableAdapter adapter = new PrintingsTableAdapter();
				adapter.Update(this);
			}

			#endregion
		}
	}
}

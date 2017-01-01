using System.Collections.Generic;
using System.Data.Services.Common;

namespace Plasticore
{
	[DataServiceKey("Id")]
	public class TestCollection
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public virtual List<TestItem> Items { get; set; }

		public override string ToString()
		{
			return string.Format("{0} [{1}] with {2} items", Name, Id, Items.Count);
		}
	}

	[DataServiceKey("Id")]
	public class TestItem
	{
		public int Id { get; set; }

		public string Name { get; set; }

//		public virtual TestCollection TheCollection { get; set; }

		public override string ToString()
		{
			return string.Format("{0} [{1}]", Name, Id);
		}
	}
}
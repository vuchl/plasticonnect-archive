using System.Collections.Generic;

namespace Plasticonnect.Engine
{
	public partial class Quote : Requisition
	{
		public override List<Engine.RequisitionItem> Items { get; set; }

		public partial class RequisitionItem : Engine.RequisitionItem
		{
		}
	}
}
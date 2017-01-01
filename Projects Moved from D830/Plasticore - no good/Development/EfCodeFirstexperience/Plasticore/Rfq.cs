using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Plasticore
{
	/// <summary>
	/// Represent a Request For Quote
	/// </summary>
	[Table("Requisition_Rfqs")]
	public class Rfq: Requisition
	{
		/// <summary>
		/// Indicates the status of an RFQ
		/// </summary>
		public enum Status
		{
			/// <summary>
			/// RFQ is active and waiting for quotes
			/// </summary>
			Active,

			/// <summary>
			/// RFQ is closed since customer has placed the order
			/// </summary>
			Closed,

			/// <summary>
			/// AccountInformation has cancelled the RFQ or it is expired
			/// </summary>
			Cancelled
		}

/*
		/// <summary>
		/// RFQ ID
		/// </summary>
		[Key]
		public string ReferenceNumber { get; set; }
*/

		/// <summary>
		/// Date and Time that RFQ submitted to the system
		/// </summary>
		public DateTime IssuedOn { get; internal set; }


//		public virtual List<RfqItem> Items { get; set; }


		/// <summary>
		/// Indicates that RFQ is open and customer accepting quotes;
		/// </summary>
		public DateTime Deadline { get; set; }

		/// <summary>
		/// Re-opens an expired/cancelled RFQ for the buyers for pricing and submit quotes
		/// </summary>
		public void Reopen()
		{
			throw new NotImplementedException();
		}

		public Rfq()
		{
			IssuedOn = DateTime.Now;
		}

		#region Validation Rules
		#endregion
	}
}
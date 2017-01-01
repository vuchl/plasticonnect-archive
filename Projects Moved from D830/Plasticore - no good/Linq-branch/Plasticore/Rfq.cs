using System;
using System.Collections.Generic;

namespace Plasticore
{
	/// <summary>
	/// Represent a Request For Quote
	/// </summary>
	public class Rfq
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
			/// Customer has cancelled the RFQ or it is expired
			/// </summary>
			Cancelled
		}

		/// <summary>
		/// RFQ ID
		/// </summary>
		public string ReferenceNumber { get; set; }

		/// <summary>
		/// Date and Time that RFQ submitted to the system
		/// </summary>
		public DateTime SubmittedDate { get; set; }

		public List<RequisitionItem> Items
		{
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}

		/// <summary>
		/// Indicates that RFQ is open and customer accepting quotes;
		/// </summary>
		public DateTime Deadline { get; internal set; }

		/// <summary>
		/// Re-opens an expired/cancelled RFQ for the buyers for pricing and submit quotes
		/// </summary>
		public void Reopen()
		{
			throw new NotImplementedException();
		}

		public AccountInformation Buyer { get; set; }

		#region Validation Rules
		#endregion
	}
}
using System.ComponentModel;

namespace Plasticonnect.DataProvider.Enums
{
	/// <summary>
	/// Status of Requisition
	/// </summary>
	public enum RequisitionStatus
	{
//        Draft: 0x0000

		/// <summary>
		/// <summary>
		/// Recently Creted Draft
		/// </summary>
		DraftCreated = 0x0000,

		/// <summary>
		/// Pending for the Quote Service to confirm if it is submitted
		/// </summary>
		DraftPendingSubmitting = 0x0010,

		/// <summary>
		/// Submitted as a Quote to the Quote Service
		/// </summary>
		DraftSubmitted = 0x0100,

		/// <summary>
		/// Draft has been cancelled by user and will be garbage collected soon
		/// </summary>
		DraftCanceled = 0x0F00,

//        Quote: 0x1000
		Submitted = 0x1100,
		Expired = 0x1E00,
		Priced = 0x1200,
		Dismissed = 0x1B00,

		/// <summary>
		/// Quote is pending by customer to be approved
		/// </summary>
		[Description("Pending Quote")]
		QuoteSent = 0x1300,
		
		RePriceRequested = 0x1500,

//        Order: 0x2000
		[Description("Open Order")]
		OrderCustomerApproved = 0x2200,
		Approved = 0x2A00,
		ReplenishStock = 0x2400,
		Refused = 0x2D00,

		/// <summary>
		/// Regency has cenceled the Order
		/// </summary>
		[Description("Canceled Order")]
		OrderCanceled = 0x2E00,

		/// <summary>
		/// Order has been fully shipped and invoiced
		/// </summary>
		[Description("Closed Order")]
		OrderClosed = 0x2F00,
	}
}
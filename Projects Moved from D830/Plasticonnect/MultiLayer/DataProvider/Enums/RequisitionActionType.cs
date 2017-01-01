namespace Plasticonnect.DataProvider.Enums
{
	/// <summary>
	/// Type of the actions that can be done on a requisition
	/// </summary>
	public enum RequisitionActionType
	{
		Created = 0,
		Canceled = 1,
		Submitted = 2,
		Priced = 3,
		RePriceRequested = 4,
		Expired = 5,
		Sent = 6,
		Approve = 7,
		Dismissed = 8,
		Close = 15,
		TransferedFromregencyRef = 88,
		All = 100
	}
}
namespace Mapping
{
	/// <summary>
	/// Defines which Sales activities to look for 
	/// Possible choices are ScheduledOnly, CompletedOnly or CompletedOrScheduled
	/// </summary>
	public enum FilterSalesActivitiesStatus
	{
		/// <summary>
		/// filter by scheduled
		/// </summary>
		ScheduledOnly=16,

		/// <summary>
		/// filtered by completed only
		/// </summary>
		CompletedOnly=17,

		/// <summary>
		/// no filter
		/// </summary>
		CompletedOrScheduled=18
	}
}
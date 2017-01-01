namespace Plasticonnect.DataAccess
{
	/// <summary>
	/// Indicates the state of a record in database on all the RegencyTables
	/// It can be Regular, Disabled or Deleted
	/// </summary>
	public enum RecordState
	{
		Regular = 1,
		Disabled = 98,
		Deleted = 99,
	}
}

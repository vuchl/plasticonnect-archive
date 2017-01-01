namespace Plasticore
{
	/// <summary>
	/// Represents a type that supports DataBaseString.
	/// </summary>
	/// <remarks>
	/// All the complex collection of Product information are stored in a string format in the database. 
	/// For example "1;40" can be translated to "40 Lbs Per Roll" since 1 means LbsPerRollSelected
	/// The Interface guarantees that corresponding types are using the same way.
	/// </remarks>
	internal interface IDataString
	{
		string DataString { get; }
	}
}
namespace Plasticonnect.Engine
{
	//--- packaging interfaces


	/// <summary>
	/// Represents any product that can have a Gusset
	/// </summary>
	public interface IGussetable
	{
		///<summary>
		///</summary>
		Gusset Gusset { get; }

		///<summary>
		///</summary>
		bool HasGusset { get; }
	}
}

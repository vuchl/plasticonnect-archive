using Plasticonnect;

namespace Plasticore
{
	/// <summary>
	/// Microvents class
	/// </summary>
	public class Microvents
	{
		/// <summary>
		/// gets/sets the type of the Microvents
		/// </summary>
		public MicroventType Type { get; set; }

		/// <summary>
		/// additional comments in regards to Microvents
		/// </summary>
		public string Comments { get; set; }

		/// <summary>
		/// string representation of the Microvents
		/// </summary>
		public override string ToString()
		{
			if (Type == MicroventType.NoMicrovents)
				return "";
			return string.Format("[{0} Microvents; {1}], ", Type, Comments);
		}
	}
}

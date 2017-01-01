using System.ComponentModel;

namespace Plasticonnect
{
	/// <summary>
	/// Defines the form of microvent holes on a product
	/// It can be NoMicrovents, Uniform, SingleRow, DoubleRow or Spiral
	/// </summary>
	public enum MicroventType
	{
		/// <summary>
		/// no microvents
		/// </summary>
		[Description("No Microvents")]
		NoMicrovents = 0,

		/// <summary>
		/// uniform microvent
		/// </summary>
		[Description("Uniform")]
		Uniform = 1,

		/// <summary>
		/// single row microvent
		/// </summary>
		[Description("Single Row")]
		SingleRow = 2,

		/// <summary>
		/// double row microvents
		/// </summary>
		[Description("Double Row")]
		DoubleRow = 3,

		/// <summary>
		/// spiral microvents
		/// </summary>
		[Description("Spiral")]
		Spiral = 4
	}
}
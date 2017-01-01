using System.ComponentModel;

namespace Plasticonnect.DataProvider.Enums
{
    /// <summary>
    /// Offers possible Core Types in packaging
    /// </summary>
    public enum CoreType
    {
		/// <summary>
		/// None
		/// </summary>
        [Description("Best Price")]
        Default = 0,

		/// <summary>
		/// 1.5" thin wal
		/// </summary>
        [Description(@"1.5"" Thin wall")]
        ThinWall_1_5 = 1,

		/// <summary>
		/// 3" Extra heavy
		/// </summary>
        [Description(@"3"" Extra Heavy")]
        ExtraHeavy = 2,

		/// <summary>
		/// 6" Heavy wall
		/// </summary>
        [Description(@"6"" Heavy wall")]
        HeavyWall = 3,

		/// <summary>
		/// 3" Regular
		/// </summary>
        [Description(@"3"" Regular")]
        Regular = 4,

		/// <summary>
		/// 3" thin wall
		/// </summary>
        [Description(@"3"" Thin wall")]
        ThinWall_3 = 5
    }
}
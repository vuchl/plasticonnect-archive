using System.ComponentModel;

namespace Plasticonnect.DataProvider.Enums
{
	/// <summary>
	/// Defines the possible SpecilaityResins used in products formula
	/// Can be RegencyDecides, Hexene or Octene
	/// </summary>
	public enum SpecialityResinTypes : short 
	{
		/// <summary>
		/// no prefrences
		/// </summary>
		[Description("No Prefrences")]
		RegencyDecides = 0,

		/// <summary>
		/// hexene
		/// </summary>
		[Description("Hexene")]
		Hexene = 1,

//        [Description("Metallocecne")]
//        Metallocecne = 2,
//
		/// <summary>
		/// Octene
		/// </summary>
		[Description("Octene")]
		Octene = 3,
//
//        [Description("SuperHexene")]
//        SuperHexene = 4,
	}
}
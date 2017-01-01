using System.ComponentModel;

namespace Plasticonnect.DataProvider.Enums
{
	/// <summary>
	/// Available Provinces/States in Canada and States
	/// </summary>
	public enum Province
	{
		/// <summary>
		/// Ontario
		/// </summary>
		[CountryRef(Country.Canada)] [Description("Ontario")] Ontario = 0,

		/// <summary>
		/// Alberta
		/// </summary>
		[CountryRef(Country.Canada)] [Description("Alberta")] Alberta = 1,

		/// <summary>
		/// Nunavut
		/// </summary>
		[CountryRef(Country.Canada)] [Description("Nunavut")] Nunavut = 2,

		/// <summary>
		/// British Columbia
		/// </summary>
		[CountryRef(Country.Canada)] [Description("British Columbia")] BritishColumbia = 3,

		/// <summary>
		/// Manitoba
		/// </summary>
		[CountryRef(Country.Canada)] [Description("Manitoba")] Manitoba = 4,

		/// <summary>
		/// Prince Edward Island
		/// </summary>
		[CountryRef(Country.Canada)] [Description("Prince Edward Island")] PrinceEdwardIsland = 5,

		/// <summary>
		/// New Brunswich
		/// </summary>
		[CountryRef(Country.Canada)] [Description("New Brunswick")] NewBrunswick = 6,

		/// <summary>
		/// Quebec
		/// </summary>
		[CountryRef(Country.Canada)] [Description("Quebec")] Quebec = 7,

		/// <summary>
		/// Newfoundland and Labrador
		/// </summary>
		[CountryRef(Country.Canada)] [Description("Newfoundland and Labrador")] NewfoundlandAndLabrador = 8,

		/// <summary>
		/// Saskatchewan
		/// </summary>
		[CountryRef(Country.Canada)] [Description("Saskatchewan")] Saskatchewan = 9,

		/// <summary>
		/// Northwest Territories
		/// </summary>
		[CountryRef(Country.Canada)] [Description("Nothwest Territories")] NothwestTerritories = 10,

		/// <summary>
		/// Yukon
		/// </summary>
		[CountryRef(Country.Canada)] [Description("Yukon")] Yukon = 11,

		/// <summary>
		/// Nova Scotia
		/// </summary>
		[CountryRef(Country.Canada)] [Description("Nova Scotia")] NovaScotia = 12,

		/// <summary>
		/// New York
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("NEW YORK")] NY = 13,

		/// <summary>
		/// California
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("CALIFORNIA")] CA = 14,

		/// <summary>
		/// Texas
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("TEXAS")] TX = 15,

		/// <summary>
		/// Alabama
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("ALABAMA")] AL = 16,

		/// <summary>
		/// Alaska
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("ALASKA")] AK = 17,

		/// <summary>
		/// American Samoa
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("AMERICAN SAMOA")] AS = 18,

		/// <summary>
		/// Arizona
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("ARIZONA")] AZ = 19,

		/// <summary>
		/// Arkansas
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("ARKANSAS")] AR = 20,

		/// <summary>
		/// Colorado
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("COLORADO")] CO = 21,

		/// <summary>
		/// Connecticut
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("CONNECTICUT")] CT = 22,

		/// <summary>
		/// Delaware
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("DELAWARE")] DE = 23,

		/// <summary>
		/// District of Columbia
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("DISTRICT OF COLUMBIA")] DC = 24,

		/// <summary>
		/// Frederated States of Micronesia
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("FEDERATED STATES OF MICRONESIA")] FM = 25,

		/// <summary>
		/// Florida
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("FLORIDA")] FL = 26,

		/// <summary>
		/// Georgia
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("GEORGIA")] GA = 27,

//		[CountryRef(Country.USA)]
//		[Description("GEORGIA")]
//		GA=28,

		/// <summary>
		/// Guam
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("GUAM")] GU = 29,

		/// <summary>
		/// Hawaii
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("HAWAII")] HI = 30,

		/// <summary>
		/// Idaho
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("IDAHO")] ID = 31,

		/// <summary>
		/// Illinois
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("ILLINOIS")] IL = 32,

		/// <summary>
		/// Indiana
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("INDIANA")] IN = 33,

		/// <summary>
		/// Iowa
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("IOWA")] IA = 34,

		/// <summary>
		/// Kansas
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("KANSAS")] KS = 35,

		/// <summary>
		/// Kentucky
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("KENTUCKY")] KY = 36,

		/// <summary>
		/// Louisiana
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("LOUISIANA")] LA = 37,

		/// <summary>
		/// Maine
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("MAINE")] ME = 38,

		/// <summary>
		/// Marshall Island
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("MARSHALL ISLANDS")] MH = 39,

		/// <summary>
		/// Maryland
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("MARYLAND")] MD = 40,

		/// <summary>
		/// Massachusette
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("MASSACHUSETTS")] MA = 41,

		/// <summary>
		/// Michigan
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("MICHIGAN")] MI = 42,

		/// <summary>
		/// Minnesota
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("MINNESOTA")] MN = 43,

		/// <summary>
		/// Mississippi
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("MISSISSIPPI")] MS = 44,

		/// <summary>
		/// Missouri
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("MISSOURI")] MO = 45,

		/// <summary>
		/// Montana
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("MONTANA")] MT = 46,

		/// <summary>
		/// Nebraska
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("NEBRASKA")] NE = 47,

		/// <summary>
		/// Nevada
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("NEVADA")] NV = 48,

		/// <summary>
		/// New Hampshire
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("NEW HAMPSHIRE")] NH = 49,

		/// <summary>
		/// New Jersy
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("NEW JERSEY")] NJ = 50,

		/// <summary>
		/// New Mexico
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("NEW MEXICO")] NM = 51,

		/// <summary>
		/// North Carolina
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("NORTH CAROLINA")] NC = 52,

		/// <summary>
		/// North Dakota
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("NORTH DAKOTA")] ND = 53,

		/// <summary>
		/// Northern Mariana Island
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("NORTHERN MARIANA ISLANDS")] MP = 54,

		/// <summary>
		/// Ohio
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("OHIO")] OH = 55,

		/// <summary>
		/// Oklahoma
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("OKLAHOMA")] OK = 56,

		/// <summary>
		/// Oredon
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("OREGON")] OR = 57,

		/// <summary>
		/// Palau
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("PALAU")] PW = 58,

		/// <summary>
		/// Pennsylvania
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("PENNSYLVANIA")] PA = 59,

		/// <summary>
		/// Puerto Rico
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("PUERTO RICO")] PR = 60,

		/// <summary>
		/// Rhode Island
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("RHODE ISLAND")] RI = 61,

		/// <summary>
		/// South Carolina
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("SOUTH CAROLINA")] SC = 62,

		/// <summary>
		/// South Dakota
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("SOUTH DAKOTA")] SD = 63,

		/// <summary>
		/// Tennessee
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("TENNESSEE")] TN = 64,

		/// <summary>
		/// Utaha
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("UTAHA")] UT = 65,

		/// <summary>
		/// Vermont
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("VERMONT")] VM = 66,

		/// <summary>
		/// Virgin Island
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("VIRGIN ISLANDS")] VI = 67,

		/// <summary>
		/// Virginia
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("VIRGINIA")] VA = 68,

		/// <summary>
		/// Washington
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("WASHINGTON")] WA = 69,

		/// <summary>
		/// West Virginia
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("WEST VIRGINIA")] WV = 70,

		/// <summary>
		/// Wisconsin
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("WISCONSIN")] WI = 71,

		/// <summary>
		/// Wyoming
		/// </summary>
		[CountryRef(Country.UnitedStates)] [Description("WYOMING")] WY = 72,  
	}
}
namespace Plasticonnect.Engine
{
	public class Address
	{
		public string City { get; set; }
		public string AddressLine1 { get; set; }
		public string AddressLine2 { get; set; }
		public string PostalCode { get; set; }
		public string Province { get; set; }
		public Country Country { get; set; }

		//todo: override Equals()
	}
}

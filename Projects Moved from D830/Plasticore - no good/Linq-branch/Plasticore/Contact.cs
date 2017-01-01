namespace Plasticore
{
	public class Contact
	{
		public string FullName { get; set; }
		public string PhoneNumber { get; set; }
		public string FaxNumber { get; set; }
		public string Email { get; set; }

        public DocumentDeliveryType Ddt { get; set; }
		public string AdditionalComments { get; set; }
	}
}
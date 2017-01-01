using System.ComponentModel.DataAnnotations;
using Plasticonnect;

namespace Plasticore
{
	[ComplexType]
	public class Address
	{
		public string AddressLine1 { get; set; }
		public string AddressLine2 { get; set; }
		public string City { get; set; }
		public string Province { get; set; }
		public string PostalCode { get; set; }
		public Country Country { get; set; }

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof (Address)) return false;
			return Equals((Address) obj);
		}

		public bool Equals(Address other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return Equals(other.AddressLine1, AddressLine1) && Equals(other.AddressLine2, AddressLine2) && Equals(other.City, City) && Equals(other.Province, Province) && Equals(other.PostalCode, PostalCode) && Equals(other.Country, Country);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var result = (AddressLine1 != null ? AddressLine1.GetHashCode() : 0);
				result = (result*397) ^ (AddressLine2 != null ? AddressLine2.GetHashCode() : 0);
				result = (result*397) ^ (City != null ? City.GetHashCode() : 0);
				result = (result*397) ^ (Province != null ? Province.GetHashCode() : 0);
				result = (result*397) ^ (PostalCode != null ? PostalCode.GetHashCode() : 0);
				result = (result*397) ^ Country.GetHashCode();
				return result;
			}
		}
	}
}

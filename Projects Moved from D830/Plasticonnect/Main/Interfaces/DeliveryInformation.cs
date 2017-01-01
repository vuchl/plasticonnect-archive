using System;
using System.Globalization;

namespace Plasticonnect.Engine
{
	public abstract class DeliveryInformation : IFormattable
	{
		/// <summary>
		/// Required at RFQ time
		/// </summary>
		public DateTime RequestedDeliveryDate { get; set; }

		/// <summary>
		/// Indicate the FOB
		/// </summary>
		public Fob Fob { get; set; }

		/// <summary>
		/// Destination address; required if (FOB == Destination) [Country & PostalCode at RFQ time; required in full at Order time]
		/// </summary>
		public Address Destination { get; set; }

		/// <summary>
		/// Additional delivery comments; Available at Order time
		/// </summary>
		public string AdditionalComments { get; set; }

		/// <summary>
		/// formats any DeliveryInformation instance with the provided UI type
		/// </summary>
		public abstract string Format(UserInterface @interface);

		public abstract string ToString(string format);
		
		public abstract string ToString(string format, IFormatProvider formatProvider);

		protected static string HandleOtherFormats(string format, object arg)
		{
			if (arg is IFormattable)
				return ((IFormattable) arg).ToString(format, CultureInfo.CurrentCulture);

			if (arg != null)
				return arg.ToString();

			return String.Empty;
		}
	}

	public partial class Rfq
	{
	}

	public partial class RfqItem
	{
		public class DeliveryInformation : Engine.DeliveryInformation
		{
			/// <summary>
			/// formats any DeliveryInformation instance with the provided UI type
			/// </summary>
			public override string Format(UserInterface @interface)
			{
				string ret;

				switch (@interface)
				{
					case UserInterface.Text:
						ret = String.Format(
							@"Requested Date: {0}
FOB: {1}
",
							RequestedDeliveryDate,
							Fob
							);
						if (Fob == Fob.Destination)
							ret += Destination.ToString(); //todo: should return Country+PostalCode only
						break;
					case UserInterface.Html:
						ret = String.Format(
							@"<span class='label'>Requested Date:</span> {0} <br />
<span class='label'>FOB:</span> {1} <br />
",
							RequestedDeliveryDate,
							Fob
							);
						if (Fob == Fob.Destination)
							ret += Destination.ToString(); //todo: should return Country+PostalCode only
						break;
					default:
						throw new FormatException(String.Format("provided format {0} is invalid", @interface));
				}

				return ret;
			}

			public override string ToString(string format)
			{
				return ToString(format, new DeliveryInformationFormat());
			}

			public override string ToString(string format, IFormatProvider formatProvider)
			{
				UserInterface userInterface;

				switch ((format ?? "t").ToLower())
				{
					case @"t":
						userInterface = UserInterface.Text;
						break;
					case @"h":
						userInterface = UserInterface.Html;
						break;
					default:
						try
						{
							return HandleOtherFormats(format, this);
						}
						catch (FormatException e)
						{
							throw new FormatException(String.Format("The format of '{0}' is invalid.", format), e);
						}
				}
				return Format(userInterface);
			}
		}
	}

	public partial class Quote : Requisition
	{
		public partial class RequisitionItem
		{
			public class DeliveryInformation : Engine.DeliveryInformation
			{
				/// <summary>
				/// Delivery date revised by seller on the Quote
				/// </summary>
				public DateTime ShippingDate { get; set; }

				/// <summary>
				/// formats any DeliveryInformation instance with the provided UI type
				/// </summary>
				public override string Format(UserInterface @interface)
				{
					switch (@interface)
					{
						case UserInterface.Text:
							throw new NotImplementedException();
						case UserInterface.Html:
							throw new NotImplementedException();
						default:
							throw new FormatException(string.Format("provided format {0} is invalid", @interface));
					}
				}

				public override string ToString(string format)
				{
					return ToString(format, new DeliveryInformationFormat());
				}

				public override string ToString(string format, IFormatProvider formatProvider)
				{
					throw new NotImplementedException();
				}
			}
		}
	}

	public partial class Order : Requisition
	{
		public partial class RequisitionItem
		{
			public class DeliveryInformation : Engine.DeliveryInformation
			{
				/// <summary>
				/// Delivery date revised by seller on the Quote
				/// </summary>
				public DateTime ShippingDate { get; set; }

				/// <summary>
				/// Person who is in charge of receiving; Required at the Order submission time
				/// </summary>
				public Contact ReceivingPerson { get; set; }

				/// <summary>
				/// formats any DeliveryInformation instance with the provided UI type
				/// </summary>
				public override string Format(UserInterface @interface)
				{
					switch (@interface)
					{
						case UserInterface.Text:
							throw new NotImplementedException();
						case UserInterface.Html:
							throw new NotImplementedException();
						default:
							throw new FormatException(string.Format("provided format {0} is invalid", @interface));
					}
				}

				public override string ToString(string format)
				{
					return ToString(format, new DeliveryInformationFormat());
				}

				public override string ToString(string format, IFormatProvider formatProvider)
				{
					throw new NotImplementedException();
				}
			}
		}
	}

	/// <summary>
	/// Supported formats (case in0sensitive): T (for Text), H (for Html)
	/// </summary>
	public class DeliveryInformationFormat : IFormatProvider, ICustomFormatter
	{
		public object GetFormat(Type formatType)
		{
			return formatType == typeof(ICustomFormatter) ? this : null;
		}

		public string Format(string format, object obj, IFormatProvider formatProvider)
		{
			if (!(obj is DeliveryInformation))
			{
				try
				{
					return HandleOtherFormats(format, obj);
				}
				catch (FormatException e)
				{
					throw new FormatException(String.Format("The format of '{0}' is invalid.", format), e);
				}
			}

			return ((DeliveryInformation)obj).ToString(format, formatProvider);
		}

		private static string HandleOtherFormats(string format, object arg)
		{
			if (arg is IFormattable)
				return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);

			if (arg != null)
				return arg.ToString();

			return String.Empty;
		}
	}
}
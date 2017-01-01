using System;
using System.Collections.Generic;
using Plasticonnect;

namespace Plasticore
{
	/// <summary>
	/// Represent a bound quote
	/// <seealso>Standalone Quotes</seealso>
	/// </summary>
	public partial class Quote 
	{
		public string AdditionalComments { get; set; }

		public string ReferenceNumber { get; set; }

		public PaymentTerms Terms { get; set; }

		public DateTime Date { get; set; }

		public List<QuoteItem> Items { get; internal set; }

		public DateTime ExpiryDate { get; set; }

	}
}
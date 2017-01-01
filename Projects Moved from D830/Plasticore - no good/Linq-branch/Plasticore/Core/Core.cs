using System;
using System.Collections.Generic;

namespace Plasticore
{
	public abstract class History
	{}

	public class Core
	{
		/// <summary>
		/// Accepts an RFQ and starts processing it.
		/// </summary>
		/// <param name="draft">brand new RFQ</param>
		/// <returns>Reference Number of the RFQ</returns>
		public static string ProcessNewRfq(Draft draft)
		{
			throw new NotImplementedException();
		}

		public static History GetHistory()
		{
			throw new NotImplementedException();
		}

		public static void PlaceOrder(Order order)
		{
			throw new NotImplementedException();
		}

		public static Rfq GetRfq(string refNumber)
		{
			throw new NotImplementedException();
		}

		public static Quote GetQuote(string quoteNumber)
		{
			throw new NotImplementedException();
		}

		public static void GetOrder(string orderNumber)
		{
			throw new NotImplementedException();
		}

		public static void Reports()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets the Active Draft for a specific accountNumber. 
		/// If there is no record, a new one will be created and returns
		/// </summary>
		public static Draft GetActiveDraft(string accountNumber)
		{
			throw new NotImplementedException();
		}

		public static Rfq GetRfqByNumber(string rfqNumber)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Submits a brand new RFQ to the core and returns its reference number
		/// </summary>
		/// <returns>RFQ number</returns>
		public static string SubmitRfq(Rfq rfq)
		{
			RfqSubmitting(rfq, new RfqSubmittingArgs { AccountNumber = rfq.Buyer.AccountNumber });

			throw new NotImplementedException();

			RfqSubmitted(rfq, new RfqSubmittedArgs { AccountNumber = rfq.Buyer.AccountNumber, RfqNumber = rfq.ReferenceNumber });
		}

		public static void SaveRfq(Rfq rfq)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Creates and returns a brand new RFQ for the provided account
		/// </summary>
		public static Rfq CreateNewRfq(AccountInformation account)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Creates and returns a bound quote
		/// <remarks>A bound quote is a quote that is bound to an RFQ. In this case user of the quote is not</remarks>
		/// <seealso>Standalone Quotes</seealso>
		/// </summary>
		public static Quote CreateNewQuote(AccountInformation account, Rfq rfq)
		{
			QuoteCreation(rfq, new QuoteCreationArgs {AccountNumber = account.AccountNumber, RfqNumber = rfq.ReferenceNumber});

			var quote = new Quote();
			throw new NotImplementedException();

			QuoteCreated(quote, new QuoteCreatedArgs {AccountNumber = account.AccountNumber, QuoteNumber = quote.ReferenceNumber});
		}

		/// <summary>
		/// Submits a quote
		/// </summary>
		public static void SubmitQuote(Quote quote)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Creates and returns one or more new purchase order draft ready to sign
		/// <remarks>
		/// A quote usually makes a single purchase order. However, for the quotes with multiple delivery requtests, system
		/// generates multiple orders for each delivery request
		/// </remarks>
		/// </summary>
		public static List<Order> CreateNewOrder(string quoteNumber)
		{
			throw new NotImplementedException();
		}

		#region Events and Delegates

		public static event OnRfqSubmitting RfqSubmitting;
		public static event OnRfqSubmitted RfqSubmitted;
		public static event OnQuoteCreation QuoteCreation;
		public static event OnQuoteCreated QuoteCreated;

		public delegate void OnRfqSubmitting(object sender, RfqSubmittingArgs args);
		public delegate void OnRfqSubmitted(object sender, RfqSubmittedArgs args);
		public delegate void OnQuoteCreation(object sender, QuoteCreationArgs args);
		public delegate void OnQuoteCreated(object sender, QuoteCreatedArgs args);

		#endregion
	}
}

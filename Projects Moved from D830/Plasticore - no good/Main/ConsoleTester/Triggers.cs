using System;
using Plasticore;

namespace ConsoleTester
{
	public class Triggers
	{
		public static void BindWorkFlowTriggers()
		{
			Core.RfqSubmitting += RfqSubmitting;
			Core.RfqSubmitted += RfqSubmitted;
			Core.QuoteCreation += QuoteCreation;
			Core.QuoteCreated += QuoteCreated;
		}

		private static void RfqSubmitted(object sender, RfqSubmittedArgs args)
		{
			Console.WriteLine("RFQ number {0} has been submitted for accountNumber {1}", args.RfqNumber, args.AccountNumber);			
		}

		private static void RfqSubmitting(object sender, RfqSubmittingArgs args)
		{
			Console.WriteLine("A new RFQ is submitting for accountNumber {0}", args.AccountNumber);
		}

		private static void QuoteCreation(object sender, QuoteCreationArgs args)
		{
			Console.WriteLine("A new quote is going to be created for RFQ {0} and Account number {1}", args.RfqNumber,
			                  args.AccountNumber);
		}

		private static void QuoteCreated(object sender, QuoteCreatedArgs args)
		{
			Console.WriteLine("Quote number {0} has been created for Account number {1}", args.QuoteNumber, args.AccountNumber);
		}
	}
}

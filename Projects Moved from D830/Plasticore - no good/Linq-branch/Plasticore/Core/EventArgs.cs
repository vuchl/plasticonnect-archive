using System;

namespace Plasticore
{
	public class RfqSubmittedArgs : EventArgs
	{
		public string AccountNumber { get; internal set; }
		public string RfqNumber { get; internal set; }
	}

	public class RfqSubmittingArgs : EventArgs
	{
		public string AccountNumber { get; internal set; }
	}

	public class QuoteCreationArgs: EventArgs
	{
		public string AccountNumber { get; internal set; }
		public string RfqNumber { get; internal set; }
	}

	public class QuoteCreatedArgs : EventArgs
	{
		public string AccountNumber { get; internal set; }
		public string QuoteNumber { get; internal set; }
	}
}

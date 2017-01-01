
using System;

namespace Plasticonnect.Engine
{
	public abstract class History
	{}

	public class Core
	{
		/// <summary>
		/// Accepts an RFQ and starts processing it.
		/// </summary>
		/// <param name="rfq">brand new RFQ</param>
		/// <returns>Reference Number of the RFQ</returns>
		public string ProcessNewRfq(Rfq rfq)
		{
			throw new NotImplementedException();
		}

		public History GetHistory()
		{
			throw new NotImplementedException();
		}

		public void PlaceOrder(Order order)
		{
			throw new NotImplementedException();
		}

		public RegisteredRfq GetRfq(string refNumber)
		{
			throw new NotImplementedException();
		}

		public void GetQuote(string quoteNumber)
		{
			throw new NotImplementedException();			
		}

		public void GetOrder(string orderNumber)
		{
			throw new NotImplementedException();			
		}

		public void Reports()
		{
			throw new NotImplementedException();
		}
	}
}

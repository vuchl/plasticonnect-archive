using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Linq;
using System.Text;

namespace Plasticore
{
    public class DataAccess
    {
        private DataModelDataContext context = new DataModelDataContext();

        public Rfq GetRfq(string refNumber)
        {
            return context.Rfqs.FirstOrDefault(rfq => rfq.RfqNumber == refNumber);
        }

        public Quote GetQuote(string quoteNumber)
        {
            return context.Quotes.FirstOrDefault(quote => quote.QuoteNumber == quoteNumber);
        }
    }
}

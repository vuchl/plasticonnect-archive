using System.Linq;

namespace Plasticore.DataAccessLayer
{
    public class DataAccess
    {
        private DataModelDataContext context = new DataModelDataContext();

        public Rfq GetRfq(string refNumber)
        {            
            context.Addresses.InsertOnSubmit(new Address());
            context.SubmitChanges();
            return context.Rfqs.FirstOrDefault(rfq => rfq.RfqNumber == refNumber);
        }

        public Quote GetQuote(string quoteNumber)
        {
            return context.Quotes.FirstOrDefault(quote => quote.QuoteNumber == quoteNumber);
        }
    }
}

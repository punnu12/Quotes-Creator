using QuotesCreator.AL.Repositories.Abstraction;
using QuotesCreator.DL;
using QuotesCreator.IL.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuotesCreator.IL.Repositories.Implementation
{
    public class GetQuoteCreatorRepository : IGetQuoteCreatorRepository
    {
        private QuoteCreatorDatabaseContext _db;
        public GetQuoteCreatorRepository(QuoteCreatorDatabaseContext db) {
            _db = db;
        }
        public async Task<Quote> GetQuote(int quoteId)
        {
            var quote = await _db.Quotes.FindAsync(quoteId);
            return quote;
        }
    }
}

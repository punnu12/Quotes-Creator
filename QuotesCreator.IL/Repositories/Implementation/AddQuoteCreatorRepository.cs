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
    public class AddQuoteCreatorRepository : IAddQuoteCreatorRepository
    {
        private QuoteCreatorDatabaseContext _db { get; set; }
        public AddQuoteCreatorRepository( QuoteCreatorDatabaseContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(List<Quote> quote)
        {
            _db.Quotes.AddRange(quote);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}

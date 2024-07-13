using QuotesCreator.AL.Repositories.Abstraction;
using QuotesCreator.AL.Services.Abstraction;
using QuotesCreator.DL;
using QuotesCreator.IL.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuotesCreator.IL.Repositories.Implementation
{
    public class DeleteQuoteCreatorRepository : IDeleteQuoteCreatorRepository
    {
        private QuoteCreatorDatabaseContext _db { get; set; }
        private IGetQuoteCreatorRepository _getQuote;
        public DeleteQuoteCreatorRepository(QuoteCreatorDatabaseContext db, IGetQuoteCreatorRepository getQuoteCreatorRepository)
        {
            _db = db;
            _getQuote = getQuoteCreatorRepository;
        }
        public async Task<bool> Delete(int id)
        {
            var quote = await _getQuote.GetQuote(id);
            _db.Quotes.Remove(quote);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}

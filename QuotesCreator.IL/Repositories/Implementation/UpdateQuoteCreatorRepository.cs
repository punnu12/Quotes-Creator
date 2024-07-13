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
    public class UpdateQuoteCreatorRepository : IUpdateQuoteCreatorRepository
    {
        private QuoteCreatorDatabaseContext _db;
        public UpdateQuoteCreatorRepository(QuoteCreatorDatabaseContext db) { 
            _db = db;
        }
        public async Task<bool> Update(Quote quote)
        {
            _db.Update(quote);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}

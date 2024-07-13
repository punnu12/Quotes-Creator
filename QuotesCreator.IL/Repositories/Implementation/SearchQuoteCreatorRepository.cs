using Microsoft.EntityFrameworkCore;
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
    public class SearchQuoteCreatorRepository : ISearchQuoteCreatorRepository
    {
        private QuoteCreatorDatabaseContext _db;
        public SearchQuoteCreatorRepository(QuoteCreatorDatabaseContext db)
        {
            _db = db;
        }
        public async Task<List<Quote>> GetAllFilteredQuoteList(QuoteFilter filterData)
        {
            var tags = (filterData.tag ?? "").ToLower().Split(',').Select(t => t.Trim());
            var quotesQuery = _db.Quotes
                .Where(_ =>
                    (_.Author.ToLower().Contains((filterData.authorName ?? string.Empty).ToLower()) || string.IsNullOrEmpty(filterData.authorName)) &&
                    (_.QuoteDesp.ToLower().Contains((filterData.desp ?? string.Empty).ToLower()) || string.IsNullOrEmpty(filterData.desp)));

            if (!string.IsNullOrEmpty(filterData.tag))
            {
                return quotesQuery.AsEnumerable().Where(q => tags.Any(_ => q.Tags.ToLower().Split(",", StringSplitOptions.None).Any(t => t.Equals(_)))).ToList();
            }
            return await quotesQuery.ToListAsync();
        }
    }
}

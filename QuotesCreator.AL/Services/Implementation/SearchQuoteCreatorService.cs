using QuotesCreator.AL.Services.Abstraction;
using QuotesCreator.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QuotesCreator.AL.Services.Implementation
{
    public class SearchQuoteCreatorService : ISearchQuoteCreatorService
    {
        private ISearchQuoteCreatorRepository _searchQuoteCreatorRepository;
        public SearchQuoteCreatorService(ISearchQuoteCreatorRepository searchQuoteCreatorRepository)
        {
            _searchQuoteCreatorRepository = searchQuoteCreatorRepository;
        }
        public Task<List<Quote>> GetAllFilteredQuoteList(QuoteFilter filterData)
        {
            try
            {
                var filteredList = _searchQuoteCreatorRepository.GetAllFilteredQuoteList(filterData);
                return filteredList;
            }
            catch
            {
               throw;
            }
        }
    }
}

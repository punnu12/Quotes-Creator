using QuotesCreator.AL.Repositories.Abstraction;
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
    public class GetQuoteCreatorService : IGetQuoteCreatorService
    {
        private IGetQuoteCreatorRepository _getQuoteCreatorRepository;
        public GetQuoteCreatorService(IGetQuoteCreatorRepository getQuoteCreatorRepository)
        {
            _getQuoteCreatorRepository = getQuoteCreatorRepository;
        }
        public Task<Quote> GetQuote(int quoteId)
        {
            try
            {
                var quote = _getQuoteCreatorRepository.GetQuote(quoteId);
                return quote;
            }
            catch
            {
                throw;
            }
        }
    }
}

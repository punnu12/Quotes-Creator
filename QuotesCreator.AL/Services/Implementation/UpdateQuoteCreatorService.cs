using QuotesCreator.AL.Repositories.Abstraction;
using QuotesCreator.AL.Services.Abstraction;
using QuotesCreator.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuotesCreator.AL.Services.Implementation
{
    public class UpdateQuoteCreatorService : IUpdateQuoteCreatorService
    {
        private IUpdateQuoteCreatorRepository _updateQuoteCreatorRepository;
        private IGetQuoteCreatorRepository _getQuoteCreatorRepository;
        public UpdateQuoteCreatorService( IUpdateQuoteCreatorRepository updateQuoteCreatorRepository, IGetQuoteCreatorRepository getQuoteCreatorRepository) {
            _updateQuoteCreatorRepository = updateQuoteCreatorRepository;
            _getQuoteCreatorRepository = getQuoteCreatorRepository;
        }
        public async Task<bool> Update(Quote quote)
        {
            try
            {
                var existingQuote = await _getQuoteCreatorRepository.GetQuote(quote.QuoteId);
                if (existingQuote == null)
                {
                    return false;
                }
                existingQuote.Author = quote.Author;
                existingQuote.Tags = quote.Tags;
                existingQuote.QuoteDesp = quote.QuoteDesp;
                var isUpdated = await _updateQuoteCreatorRepository.Update(existingQuote);
                return isUpdated;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

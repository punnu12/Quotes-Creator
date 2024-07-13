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
    public class AddQuoteCreatorService : IAddQuoteCreatorService
    {
        private IAddQuoteCreatorRepository _addQuoteCreatorRepository;
        public AddQuoteCreatorService( IAddQuoteCreatorRepository addQuoteCreatorRepository) {
            _addQuoteCreatorRepository = addQuoteCreatorRepository;
        }
        public async Task<bool> Create(List<Quote> quote)
        {
            try
            {
                var isSuccess = await _addQuoteCreatorRepository.Create(quote);
                return isSuccess;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

using QuotesCreator.AL.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuotesCreator.AL.Services.Implementation
{
    public class DeleteQuoteCreatorService : IDeleteQuoteCreatorService
    {
        private IDeleteQuoteCreatorRepository _deleteQuoteCreatorRepository;
        public DeleteQuoteCreatorService(IDeleteQuoteCreatorRepository deleteQuoteCreatorRepository) 
        {
            _deleteQuoteCreatorRepository = deleteQuoteCreatorRepository;
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                var isDelete = await _deleteQuoteCreatorRepository.Delete(id);
                return isDelete;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

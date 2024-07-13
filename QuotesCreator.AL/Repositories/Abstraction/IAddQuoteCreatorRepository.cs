using QuotesCreator.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuotesCreator.AL.Repositories.Abstraction
{
    public interface IAddQuoteCreatorRepository
    {
        Task<bool> Create(List<Quote> quote);
    }
}

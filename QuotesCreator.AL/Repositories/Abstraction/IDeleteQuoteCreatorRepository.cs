using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuotesCreator.AL.Services.Abstraction
{
    public interface IDeleteQuoteCreatorRepository
    {
        Task<bool> Delete(int id);
    }
}

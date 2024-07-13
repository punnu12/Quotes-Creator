﻿using QuotesCreator.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuotesCreator.AL.Repositories.Abstraction
{
    public interface IGetQuoteCreatorRepository
    {
        Task<Quote> GetQuote(int quoteId);
    }
}

using Microsoft.EntityFrameworkCore;
using QuotesCreator.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuotesCreator.IL.DBContext
{
    public class QuoteCreatorDatabaseContext : DbContext
    {
        public QuoteCreatorDatabaseContext(DbContextOptions<QuoteCreatorDatabaseContext> options) : base(options)
        {

        }
        public DbSet<Quote> Quotes { get; set; }
    }
}

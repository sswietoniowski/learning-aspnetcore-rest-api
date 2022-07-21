using Microsoft.EntityFrameworkCore;

using minimal.Configurations.Entities;
using minimal.Models;

namespace minimal.DataAccess.Data
{
    public class QuotesDbContext : DbContext
    {
        public DbSet<Quote> Quotes => Set<Quote>();

        public QuotesDbContext(DbContextOptions<QuotesDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // alternatively one might use: https://docs.microsoft.com/pl-pl/ef/core/modeling/data-seeding
            builder.ApplyConfiguration(new QuoteConfiguration());
        }
    }
}
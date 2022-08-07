using Microsoft.EntityFrameworkCore;
using mvc.Configurations.Entities;
using mvc.Models;

namespace mvc.DataAccess.Data
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
using Microsoft.EntityFrameworkCore;
using mvc.Configurations.Entities;
using mvc.Models;

namespace mvc.DataAccess
{
    public class QuotesDbContext : DbContext
    {
        public DbSet<Quote> Quotes { get; set; }

        public QuotesDbContext(DbContextOptions<QuotesDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new QuoteConfiguration());
        }
    }
}
using Microsoft.EntityFrameworkCore;
using mvc.Configurations.Entities;
using mvc.DataAccess.Entities;

namespace mvc.DataAccess.Data;

public class QuotesDbContext : DbContext
{
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Language> Languages => Set<Language>();
    public DbSet<Quote> Quotes => Set<Quote>();

    public QuotesDbContext(DbContextOptions<QuotesDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // alternatively one might use: https://docs.microsoft.com/pl-pl/ef/core/modeling/data-seeding
        builder.ApplyConfiguration(new AuthorConfiguration());
        builder.ApplyConfiguration(new LanguageConfiguration());
        builder.ApplyConfiguration(new QuoteConfiguration());
    }
}
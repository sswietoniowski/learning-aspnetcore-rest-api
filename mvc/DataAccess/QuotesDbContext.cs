using Microsoft.EntityFrameworkCore;
using mvc.Models;

namespace mvc.DataAccess
{
    public class QuotesDbContext : DbContext
    {
        public QuotesDbContext(DbContextOptions<QuotesDbContext> options) : base(options)
        {
        }

        public DbSet<Quote> Quotes { get; set; }
    }
}
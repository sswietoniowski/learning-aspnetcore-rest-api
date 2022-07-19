using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mvc.Models;

namespace mvc.Configurations.Entities
{
    public class QuoteConfiguration : IEntityTypeConfiguration<Quote>
    {
        public void Configure(EntityTypeBuilder<Quote> builder)
        {
            builder.HasData(
                new Quote
                {
                    Id = 1,
                    Text = "Per aspera ad astra.",
                    Author = "Unknown",
                    Language = "Latin"
                },
                new Quote
                {
                    Id = 2,
                    Text = "Jestem życiem, które pragnie żyć, pośród życia, które pragnie żyć.",
                    Author = "Albert Shweitzer",
                    Language = "Polish"
                }, new Quote
                {
                    Id = 3,
                    Text = "Don't ever be the first, don't ever be the last, and don't ever volunteer for anything.",
                    Author = "Unknown",
                    Language = "English"
                },
                new Quote
                {
                    Id = 4,
                    Text = "Niczego się nie wyrzekać, do niczego się nie przywiązywać.",
                    Author = "Anthony de Mello",
                    Language = "Polish"
                }
            );
        }
    }
}

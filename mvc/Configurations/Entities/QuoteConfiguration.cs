using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mvc.DataAccess.Entities;

namespace mvc.Configurations.Entities;

public class QuoteConfiguration : IEntityTypeConfiguration<QuoteEntity>
{
    public void Configure(EntityTypeBuilder<QuoteEntity> builder)
    {
        builder.HasData(
            new QuoteEntity
            {
                Id = 1,
                Text = "Per aspera ad astra.",
                Author = "Unknown",
                Language = "Latin"
            },
            new QuoteEntity
            {
                Id = 2,
                Text = "Jestem życiem, które pragnie żyć, pośród życia, które pragnie żyć.",
                Author = "Albert Shweitzer",
                Language = "Polish"
            }, new QuoteEntity
            {
                Id = 3,
                Text = "Never be the first, never be the last, and never ever volunteer to do anything.",
                Author = "Military Wisdom",
                Language = "English"
            },
            new QuoteEntity
            {
                Id = 4,
                Text = "Niczego się nie wyrzekać, do niczego się nie przywiązywać.",
                Author = "Anthony de Mello",
                Language = "Polish"
            }
        );
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mvc.DataAccess.Entities;

namespace mvc.Configurations.Entities;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.HasData(
            new Author
            {
                Id = 1,
                Name = "Albert Shweitzer",
                Biography = @"Ludwig Philipp Albert Schweitzer OM (14 January 1875 – 4 September 1965) 
was an Alsatian-German/French polymath. He was a theologian, organist, musicologist, writer, 
humanitarian, philosopher, and physician."
            },
            new Author
            {
                Id = 2,
                Name = "Anthony de Mello",
                Biography = @"Anthony de Mello, also known as Tony de Mello (4 September 1931 – 2 June 
1987), was an Indian Jesuit priest and psychotherapist. A spiritual teacher, writer, and public 
speaker, de Mello wrote several books on spirituality and hosted numerous spiritual retreats 
and conferences. He continues to be known for his storytelling which drew from the various 
mystical traditions of both East and West and for introducing many people in the West to 
mindfulness-based practices he sometimes called ""awareness prayer""."
            },
            new Author
            {
                Id = 3,
                Name = "Military Wisdom"
            });
    }
}

public class LanguageConfiguration : IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> builder)
    {
        builder.HasData(
            new Language
            {
                Id = 1,
                Name = "Latin"
            },
            new Language
            {
                Id = 2,
                Name = "Polish"
            },
            new Language
            {
                Id = 3,
                Name = "English"
            });
    }
}

public class QuoteConfiguration : IEntityTypeConfiguration<Quote>
{
    public void Configure(EntityTypeBuilder<Quote> builder)
    {
        builder.HasData(
            new Quote
            {
                Id = 1,
                Text = "Per aspera ad astra.",
                AuthorId = null,
                LanguageId = 1
            },
            new Quote
            {
                Id = 2,
                Text = "Jestem życiem, które pragnie żyć, pośród życia, które pragnie żyć.",
                AuthorId = 1,
                LanguageId = 2
            }, new Quote
            {
                Id = 3,
                Text = "Never be the first, never be the last, and never ever volunteer to do anything.",
                AuthorId = 3,
                LanguageId = 3
            },
            new Quote
            {
                Id = 4,
                Text = "Niczego się nie wyrzekać, do niczego się nie przywiązywać.",
                AuthorId = 2,
                LanguageId = 2
            }
        );
    }
}
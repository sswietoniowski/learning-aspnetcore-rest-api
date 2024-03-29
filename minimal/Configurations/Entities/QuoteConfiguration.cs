﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using minimal.DataAccess.Entities;

namespace minimal.Configurations.Entities;

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
                Text = "Never be the first, never be the last, and never ever volunteer to do anything.",
                Author = "Military Wisdom",
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
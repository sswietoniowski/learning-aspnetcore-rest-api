﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using mvc.DataAccess;

namespace mvc.Migrations
{
    [DbContext(typeof(QuotesDbContext))]
    partial class QuotesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("mvc.Models.Quote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.ToTable("Quotes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Unknown",
                            Language = "Latin",
                            Text = "Per aspera ad astra."
                        },
                        new
                        {
                            Id = 2,
                            Author = "Albert Shweitzer",
                            Language = "Polish",
                            Text = "Jestem życiem, które pragnie żyć, pośród życia, które pragnie żyć."
                        },
                        new
                        {
                            Id = 3,
                            Author = "Unknown",
                            Language = "English",
                            Text = "Don't ever be the first, don't ever be the last, and don't ever volunteer for anything."
                        },
                        new
                        {
                            Id = 4,
                            Author = "Anthony de Mello",
                            Language = "Polish",
                            Text = "Niczego się nie wyrzekać, do niczego się nie przywiązywać."
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

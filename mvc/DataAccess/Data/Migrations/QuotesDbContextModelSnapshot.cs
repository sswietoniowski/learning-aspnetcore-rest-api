﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using mvc.DataAccess.Data;

#nullable disable

namespace mvc.Migrations
{
    [DbContext(typeof(QuotesDbContext))]
    partial class QuotesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("mvc.DataAccess.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Biography")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Biography = "Ludwig Philipp Albert Schweitzer OM (14 January 1875 – 4 September 1965) \r\nwas an Alsatian-German/French polymath. He was a theologian, organist, musicologist, writer, \r\nhumanitarian, philosopher, and physician.",
                            Name = "Albert Shweitzer"
                        },
                        new
                        {
                            Id = 2,
                            Biography = "Anthony de Mello, also known as Tony de Mello (4 September 1931 – 2 June \r\n1987), was an Indian Jesuit priest and psychotherapist. A spiritual teacher, writer, and public \r\nspeaker, de Mello wrote several books on spirituality and hosted numerous spiritual retreats \r\nand conferences. He continues to be known for his storytelling which drew from the various \r\nmystical traditions of both East and West and for introducing many people in the West to \r\nmindfulness-based practices he sometimes called \"awareness prayer\".",
                            Name = "Anthony de Mello"
                        },
                        new
                        {
                            Id = 3,
                            Biography = "",
                            Name = "Military Wisdom"
                        });
                });

            modelBuilder.Entity("mvc.DataAccess.Entities.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Languages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Latin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Polish"
                        },
                        new
                        {
                            Id = 3,
                            Name = "English"
                        });
                });

            modelBuilder.Entity("mvc.DataAccess.Entities.Quote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int?>("AuthorId1")
                        .HasColumnType("int");

                    b.Property<int?>("LanguageId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("AuthorId1");

                    b.ToTable("Quotes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LanguageId = 1,
                            Text = "Per aspera ad astra."
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 1,
                            LanguageId = 2,
                            Text = "Jestem życiem, które pragnie żyć, pośród życia, które pragnie żyć."
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 3,
                            LanguageId = 3,
                            Text = "Never be the first, never be the last, and never ever volunteer to do anything."
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = 2,
                            LanguageId = 2,
                            Text = "Niczego się nie wyrzekać, do niczego się nie przywiązywać."
                        });
                });

            modelBuilder.Entity("mvc.DataAccess.Entities.Quote", b =>
                {
                    b.HasOne("mvc.DataAccess.Entities.Language", "Language")
                        .WithMany("Quotes")
                        .HasForeignKey("AuthorId");

                    b.HasOne("mvc.DataAccess.Entities.Author", "Author")
                        .WithMany("Quotes")
                        .HasForeignKey("AuthorId1");

                    b.Navigation("Author");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("mvc.DataAccess.Entities.Author", b =>
                {
                    b.Navigation("Quotes");
                });

            modelBuilder.Entity("mvc.DataAccess.Entities.Language", b =>
                {
                    b.Navigation("Quotes");
                });
#pragma warning restore 612, 618
        }
    }
}

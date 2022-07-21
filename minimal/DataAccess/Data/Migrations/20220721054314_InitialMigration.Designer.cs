﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using minimal.DataAccess.Data;

#nullable disable

namespace minimal.DataAccess.Data.Migrations
{
    [DbContext(typeof(QuotesDbContext))]
    [Migration("20220721054314_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("minimal.Models.Quote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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
                            Author = "Military Wisdom",
                            Language = "English",
                            Text = "Never be the first, never be the last, and never ever volunteer to do anything."
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

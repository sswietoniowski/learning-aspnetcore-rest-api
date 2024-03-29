﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace mvc.Migrations
{
    public partial class SeedingQuotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Author", "Language", "Text" },
                values: new object[,]
                {
                    { 1, "Unknown", "Latin", "Per aspera ad astra." },
                    { 2, "Albert Shweitzer", "Polish", "Jestem życiem, które pragnie żyć, pośród życia, które pragnie żyć." },
                    { 3, "Military Wisdom", "English", "Never be the first, never be the last, and never ever volunteer to do anything." },
                    { 4, "Anthony de Mello", "Polish", "Niczego się nie wyrzekać, do niczego się nie przywiązywać." }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}

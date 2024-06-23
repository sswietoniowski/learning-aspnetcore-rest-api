using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace minimal.DataAccess.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Language = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.Id);
                });

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
            migrationBuilder.DropTable(
                name: "Quotes");
        }
    }
}

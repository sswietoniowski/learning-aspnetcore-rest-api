using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mvc.Migrations
{
    public partial class ExtractingAuthorAndLanguageToSeparaterEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Quotes");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Quotes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AuthorId1",
                table: "Quotes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Quotes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Biography", "Name" },
                values: new object[,]
                {
                    { 1, "Ludwig Philipp Albert Schweitzer OM (14 January 1875 – 4 September 1965) \r\nwas an Alsatian-German/French polymath. He was a theologian, organist, musicologist, writer, \r\nhumanitarian, philosopher, and physician.", "Albert Shweitzer" },
                    { 2, "Anthony de Mello, also known as Tony de Mello (4 September 1931 – 2 June \r\n1987), was an Indian Jesuit priest and psychotherapist. A spiritual teacher, writer, and public \r\nspeaker, de Mello wrote several books on spirituality and hosted numerous spiritual retreats \r\nand conferences. He continues to be known for his storytelling which drew from the various \r\nmystical traditions of both East and West and for introducing many people in the West to \r\nmindfulness-based practices he sometimes called \"awareness prayer\".", "Anthony de Mello" },
                    { 3, "", "Military Wisdom" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Latin" },
                    { 2, "Polish" },
                    { 3, "English" }
                });

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 1,
                column: "LanguageId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AuthorId", "LanguageId" },
                values: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AuthorId", "LanguageId" },
                values: new object[] { 3, 3 });

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AuthorId", "LanguageId" },
                values: new object[] { 2, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_AuthorId",
                table: "Quotes",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_AuthorId1",
                table: "Quotes",
                column: "AuthorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_Authors_AuthorId1",
                table: "Quotes",
                column: "AuthorId1",
                principalTable: "Authors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_Languages_AuthorId",
                table: "Quotes",
                column: "AuthorId",
                principalTable: "Languages",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_Authors_AuthorId1",
                table: "Quotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_Languages_AuthorId",
                table: "Quotes");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_Quotes_AuthorId",
                table: "Quotes");

            migrationBuilder.DropIndex(
                name: "IX_Quotes_AuthorId1",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "AuthorId1",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Quotes");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Quotes",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Quotes",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Author", "Language" },
                values: new object[] { "Unknown", "Latin" });

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Author", "Language" },
                values: new object[] { "Albert Shweitzer", "Polish" });

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Author", "Language" },
                values: new object[] { "Military Wisdom", "English" });

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Author", "Language" },
                values: new object[] { "Anthony de Mello", "Polish" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace SongsList.Migrations
{
    public partial class AddingGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GenreId",
                table: "Songs",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    GenreId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.GenreId);
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "GenreId", "Name" },
                values: new object[,]
                {
                    { "M", "Metal" },
                    { "R", "Rap" },
                    { "H", "Hip Pop" },
                    { "RC", "Rock" }
                });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "SongId",
                keyValue: 1,
                column: "GenreId",
                value: "M");

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "SongId",
                keyValue: 2,
                column: "GenreId",
                value: "RC");

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "SongId",
                keyValue: 3,
                column: "GenreId",
                value: "R");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_GenreId",
                table: "Songs",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Genre_GenreId",
                table: "Songs",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Genre_GenreId",
                table: "Songs");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropIndex(
                name: "IX_Songs_GenreId",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Songs");
        }
    }
}

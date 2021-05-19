using Microsoft.EntityFrameworkCore.Migrations;

namespace SongsList.Migrations
{
    public partial class fixGenreTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Genre_GenreId",
                table: "Songs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genre",
                table: "Genre");

            migrationBuilder.RenameTable(
                name: "Genre",
                newName: "Genres");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Genres_GenreId",
                table: "Songs",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Genres_GenreId",
                table: "Songs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.RenameTable(
                name: "Genres",
                newName: "Genre");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genre",
                table: "Genre",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Genre_GenreId",
                table: "Songs",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

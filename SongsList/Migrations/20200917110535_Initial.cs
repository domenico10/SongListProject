using Microsoft.EntityFrameworkCore.Migrations;

namespace SongsList.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    SongId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.SongId);
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "SongId", "Name", "Rating", "Year" },
                values: new object[] { 1, "Master of Puppets", 5, 1980 });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "SongId", "Name", "Rating", "Year" },
                values: new object[] { 2, "Wonderwall", 4, 1990 });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "SongId", "Name", "Rating", "Year" },
                values: new object[] { 3, "Lose Yourself", 1, 2005 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Songs");
        }
    }
}

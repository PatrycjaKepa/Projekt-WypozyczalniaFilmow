using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt_WypozyczalniaFilmow.Migrations
{
    public partial class UpdateLendModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MovieName",
                table: "Lend",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieName",
                table: "Lend");
        }
    }
}

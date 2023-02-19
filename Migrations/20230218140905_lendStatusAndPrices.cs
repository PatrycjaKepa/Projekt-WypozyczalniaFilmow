using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt_WypozyczalniaFilmow.Migrations
{
    public partial class lendStatusAndPrices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Lend",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "lendStatus",
                table: "Lend",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Lend");

            migrationBuilder.DropColumn(
                name: "lendStatus",
                table: "Lend");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt_WypozyczalniaFilmow.Migrations
{
    public partial class AddLendModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Lend",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "BeingLate",
                table: "Lend",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Client",
                table: "Lend",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "HowMuchWeeks",
                table: "Lend",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "RentDate",
                table: "Lend",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeingLate",
                table: "Lend");

            migrationBuilder.DropColumn(
                name: "Client",
                table: "Lend");

            migrationBuilder.DropColumn(
                name: "HowMuchWeeks",
                table: "Lend");

            migrationBuilder.DropColumn(
                name: "RentDate",
                table: "Lend");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Lend",
                newName: "id");
        }
    }
}

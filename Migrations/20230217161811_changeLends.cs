using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt_WypozyczalniaFilmow.Migrations
{
    public partial class changeLends : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Client",
                table: "Lend");

            migrationBuilder.DropColumn(
                name: "MovieName",
                table: "Lend");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReturnDate",
                table: "Lend",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Lend",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Lend_MovieId",
                table: "Lend",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lend_Movie_MovieId",
                table: "Lend",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lend_Movie_MovieId",
                table: "Lend");

            migrationBuilder.DropIndex(
                name: "IX_Lend_MovieId",
                table: "Lend");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Lend");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReturnDate",
                table: "Lend",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Client",
                table: "Lend",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MovieName",
                table: "Lend",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

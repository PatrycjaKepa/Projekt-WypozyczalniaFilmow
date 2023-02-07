using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt_WypozyczalniaFilmow.Migrations
{
    public partial class ChangeNameAndTypeBithdateColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Movie",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Movie",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Movie",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "category",
                table: "Movie",
                newName: "Category");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Movie",
                newName: "Id");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthdate",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthdate",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Movie",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Movie",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Movie",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Movie",
                newName: "category");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Movie",
                newName: "id");

            migrationBuilder.AddColumn<int>(
                name: "DateTime",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

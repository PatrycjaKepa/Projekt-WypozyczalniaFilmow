using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt_WypozyczalniaFilmow.Migrations
{
    public partial class AddLendUserOneToManyRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Lend",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Lend_UserId",
                table: "Lend",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lend_User_UserId",
                table: "Lend",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lend_User_UserId",
                table: "Lend");

            migrationBuilder.DropIndex(
                name: "IX_Lend_UserId",
                table: "Lend");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Lend");
        }
    }
}

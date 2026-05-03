using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddDeleteCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phones_Users_UserId",
                table: "Phones");

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_Users_UserId",
                table: "Phones",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phones_Users_UserId",
                table: "Phones");

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_Users_UserId",
                table: "Phones",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}

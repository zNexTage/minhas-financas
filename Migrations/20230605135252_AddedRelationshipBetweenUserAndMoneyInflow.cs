using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinhasFinancas.Migrations
{
    /// <inheritdoc />
    public partial class AddedRelationshipBetweenUserAndMoneyInflow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "MoneyInflows",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyInflows_UserId",
                table: "MoneyInflows",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MoneyInflows_AspNetUsers_UserId",
                table: "MoneyInflows",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoneyInflows_AspNetUsers_UserId",
                table: "MoneyInflows");

            migrationBuilder.DropIndex(
                name: "IX_MoneyInflows_UserId",
                table: "MoneyInflows");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MoneyInflows");
        }
    }
}

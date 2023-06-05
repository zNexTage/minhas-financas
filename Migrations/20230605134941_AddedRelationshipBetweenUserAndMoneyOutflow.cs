using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinhasFinancas.Migrations
{
    /// <inheritdoc />
    public partial class AddedRelationshipBetweenUserAndMoneyOutflow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "MoneyOutflows",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyOutflows_UserId",
                table: "MoneyOutflows",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MoneyOutflows_AspNetUsers_UserId",
                table: "MoneyOutflows",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoneyOutflows_AspNetUsers_UserId",
                table: "MoneyOutflows");

            migrationBuilder.DropIndex(
                name: "IX_MoneyOutflows_UserId",
                table: "MoneyOutflows");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MoneyOutflows");
        }
    }
}

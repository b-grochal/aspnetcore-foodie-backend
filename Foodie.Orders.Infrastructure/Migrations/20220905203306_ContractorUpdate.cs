using Microsoft.EntityFrameworkCore.Migrations;

namespace Foodie.Orders.Infrastructure.Migrations
{
    public partial class ContractorUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Contractors_BuyerId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "ContractorId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ContractorId",
                table: "Orders",
                column: "ContractorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Contractors_ContractorId",
                table: "Orders",
                column: "ContractorId",
                principalTable: "Contractors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Contractors_ContractorId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ContractorId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ContractorId",
                table: "Orders");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Contractors_BuyerId",
                table: "Orders",
                column: "BuyerId",
                principalTable: "Contractors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

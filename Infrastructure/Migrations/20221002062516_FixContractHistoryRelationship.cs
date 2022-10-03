using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class FixContractHistoryRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractHistories_Renters_UserId",
                table: "ContractHistories");

            migrationBuilder.DropIndex(
                name: "IX_ContractHistories_UserId",
                table: "ContractHistories");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "ContractHistories");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ContractHistories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "ContractHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ContractHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ContractHistories_UserId",
                table: "ContractHistories",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractHistories_Renters_UserId",
                table: "ContractHistories",
                column: "UserId",
                principalTable: "Renters",
                principalColumn: "RenterId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

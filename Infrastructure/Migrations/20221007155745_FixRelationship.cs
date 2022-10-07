using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class FixRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseHistories_Expenses_ExpenseId",
                table: "ExpenseHistories");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Contracts");

            migrationBuilder.RenameColumn(
                name: "PaymentStatus",
                table: "PaymentType",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "PaymentName",
                table: "PaymentType",
                newName: "Name");

            migrationBuilder.AlterColumn<int>(
                name: "ExpenseId",
                table: "ExpenseHistories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseHistories_Expenses_ExpenseId",
                table: "ExpenseHistories",
                column: "ExpenseId",
                principalTable: "Expenses",
                principalColumn: "ExpenseId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseHistories_Expenses_ExpenseId",
                table: "ExpenseHistories");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "PaymentType",
                newName: "PaymentStatus");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "PaymentType",
                newName: "PaymentName");

            migrationBuilder.AlterColumn<int>(
                name: "ExpenseId",
                table: "ExpenseHistories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Contracts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseHistories_Expenses_ExpenseId",
                table: "ExpenseHistories",
                column: "ExpenseId",
                principalTable: "Expenses",
                principalColumn: "ExpenseId");
        }
    }
}

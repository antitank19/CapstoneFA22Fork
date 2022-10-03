using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class FixInvoiceRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceInvoiceHistory");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "InvoiceHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceHistories_InvoiceId",
                table: "InvoiceHistories",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceHistories_Invoices_InvoiceId",
                table: "InvoiceHistories",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "InvoiceId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceHistories_Invoices_InvoiceId",
                table: "InvoiceHistories");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceHistories_InvoiceId",
                table: "InvoiceHistories");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "InvoiceHistories");

            migrationBuilder.CreateTable(
                name: "InvoiceInvoiceHistory",
                columns: table => new
                {
                    InvoiceHistoriesInvoiceHistoryId = table.Column<int>(type: "int", nullable: false),
                    InvoicesInvoiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceInvoiceHistory", x => new { x.InvoiceHistoriesInvoiceHistoryId, x.InvoicesInvoiceId });
                    table.ForeignKey(
                        name: "FK_InvoiceInvoiceHistory_InvoiceHistories_InvoiceHistoriesInvoiceHistoryId",
                        column: x => x.InvoiceHistoriesInvoiceHistoryId,
                        principalTable: "InvoiceHistories",
                        principalColumn: "InvoiceHistoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceInvoiceHistory_Invoices_InvoicesInvoiceId",
                        column: x => x.InvoicesInvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceInvoiceHistory_InvoicesInvoiceId",
                table: "InvoiceInvoiceHistory",
                column: "InvoicesInvoiceId");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Payments_PaymentId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Services_ServiceEntityId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Renters_RenterId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_ServiceEntityId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_Bills_PaymentId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Bills");

            migrationBuilder.RenameColumn(
                name: "RenterId",
                table: "Payments",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_RenterId",
                table: "Payments",
                newName: "IX_Payments_OrderId");

            migrationBuilder.RenameColumn(
                name: "ServiceEntityId",
                table: "OrderDetails",
                newName: "ServiceId");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Renters",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Renters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ServiceEntityServiceId",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ServiceEntityServiceId",
                table: "OrderDetails",
                column: "ServiceEntityServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Services_ServiceEntityServiceId",
                table: "OrderDetails",
                column: "ServiceEntityServiceId",
                principalTable: "Services",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Orders_OrderId",
                table: "Payments",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Services_ServiceEntityServiceId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Orders_OrderId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_ServiceEntityServiceId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Renters");

            migrationBuilder.DropColumn(
                name: "ServiceEntityServiceId",
                table: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Payments",
                newName: "RenterId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                newName: "IX_Payments_RenterId");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "OrderDetails",
                newName: "ServiceEntityId");

            migrationBuilder.AlterColumn<int>(
                name: "Phone",
                table: "Renters",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "Bills",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ServiceEntityId",
                table: "OrderDetails",
                column: "ServiceEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_PaymentId",
                table: "Bills",
                column: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Payments_PaymentId",
                table: "Bills",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Services_ServiceEntityId",
                table: "OrderDetails",
                column: "ServiceEntityId",
                principalTable: "Services",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Renters_RenterId",
                table: "Payments",
                column: "RenterId",
                principalTable: "Renters",
                principalColumn: "RenterId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

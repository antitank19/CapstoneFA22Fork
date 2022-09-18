using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UpdatedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Room",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerPhone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.OwnerId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Room_OwnerId",
                table: "Room",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Owner_OwnerId",
                table: "Room",
                column: "OwnerId",
                principalTable: "Owner",
                principalColumn: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_Owner_OwnerId",
                table: "Room");

            migrationBuilder.DropTable(
                name: "Owner");

            migrationBuilder.DropIndex(
                name: "IX_Room_OwnerId",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Room");
        }
    }
}

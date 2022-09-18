using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UpdatedAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuildingForRent_Address_AddressId",
                table: "BuildingForRent");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRent_Room_RoomId",
                table: "UserRent");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRent_User_UserId",
                table: "UserRent");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropIndex(
                name: "IX_BuildingForRent_AddressId",
                table: "BuildingForRent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRent",
                table: "UserRent");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "BuildingForRent");

            migrationBuilder.RenameTable(
                name: "UserRent",
                newName: "RentEntity");

            migrationBuilder.RenameIndex(
                name: "IX_UserRent_UserId",
                table: "RentEntity",
                newName: "IX_RentEntity_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRent_RoomId",
                table: "RentEntity",
                newName: "IX_RentEntity_RoomId");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "University",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "University",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "University",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "University",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RentEntity",
                table: "RentEntity",
                column: "RentEntityId");

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "District",
                columns: table => new
                {
                    DistrictId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistrictName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.DistrictId);
                    table.ForeignKey(
                        name: "FK_District_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ward",
                columns: table => new
                {
                    WardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WardName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ward", x => x.WardId);
                    table.ForeignKey(
                        name: "FK_Ward_District_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "District",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuildingForRent_WardId",
                table: "BuildingForRent",
                column: "WardId");

            migrationBuilder.CreateIndex(
                name: "IX_District_CityId",
                table: "District",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Ward_DistrictId",
                table: "Ward",
                column: "DistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingForRent_Ward_WardId",
                table: "BuildingForRent",
                column: "WardId",
                principalTable: "Ward",
                principalColumn: "WardId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RentEntity_Room_RoomId",
                table: "RentEntity",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RentEntity_User_UserId",
                table: "RentEntity",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuildingForRent_Ward_WardId",
                table: "BuildingForRent");

            migrationBuilder.DropForeignKey(
                name: "FK_RentEntity_Room_RoomId",
                table: "RentEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_RentEntity_User_UserId",
                table: "RentEntity");

            migrationBuilder.DropTable(
                name: "Ward");

            migrationBuilder.DropTable(
                name: "District");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropIndex(
                name: "IX_BuildingForRent_WardId",
                table: "BuildingForRent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RentEntity",
                table: "RentEntity");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "University");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "University");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "University");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "University");

            migrationBuilder.RenameTable(
                name: "RentEntity",
                newName: "UserRent");

            migrationBuilder.RenameIndex(
                name: "IX_RentEntity_UserId",
                table: "UserRent",
                newName: "IX_UserRent_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RentEntity_RoomId",
                table: "UserRent",
                newName: "IX_UserRent_RoomId");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "BuildingForRent",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRent",
                table: "UserRent",
                column: "RentEntityId");

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressLine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ward = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuildingForRent_AddressId",
                table: "BuildingForRent",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingForRent_Address_AddressId",
                table: "BuildingForRent",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRent_Room_RoomId",
                table: "UserRent",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRent_User_UserId",
                table: "UserRent",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

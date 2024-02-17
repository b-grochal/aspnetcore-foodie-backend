using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Foode.Identity.Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    IsLocked = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_ApplicationUsers_Id",
                        column: x => x.Id,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_ApplicationUsers_Id",
                        column: x => x.Id,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderHandlers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHandlers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderHandlers_ApplicationUsers_Id",
                        column: x => x.Id,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpirationTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ApplicationUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_ApplicationUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ApplicationUsers",
                columns: new[] { "Id", "AccessFailedCount", "CreatedBy", "CreatedDate", "Email", "FirstName", "IsActive", "IsLocked", "LastModifiedBy", "LastModifiedDate", "LastName", "PasswordHash", "PhoneNumber", "Role" },
                values: new object[] { 1, 0, "Seed", new DateTimeOffset(new DateTime(2024, 2, 10, 16, 55, 40, 836, DateTimeKind.Unspecified).AddTicks(6541), new TimeSpan(0, 1, 0, 0, 0)), "michsco123@foodie.com", "Michael", true, false, null, null, "Scott", "$2a$11$PoFX6aj9gOhvC0GmgA9C8e4Rlo749VwDWom0vFY9IZ1Ber8XHjUUW", "123-456-789", 1 });

            migrationBuilder.InsertData(
                table: "ApplicationUsers",
                columns: new[] { "Id", "AccessFailedCount", "CreatedBy", "CreatedDate", "Email", "FirstName", "IsActive", "IsLocked", "LastModifiedBy", "LastModifiedDate", "LastName", "PasswordHash", "PhoneNumber", "Role" },
                values: new object[] { 3, 0, "Seed", new DateTimeOffset(new DateTime(2024, 2, 10, 16, 55, 41, 148, DateTimeKind.Unspecified).AddTicks(7060), new TimeSpan(0, 1, 0, 0, 0)), "jimhal123@foodie.com", "Jim", true, false, null, null, "Halpert", "$2a$11$ZyuO0oZMZXIrpBXKOI.mhOrMEeaLzxv4GFN3qsm1gy20fJy1LWUQe", "123-456-789", 3 });

            migrationBuilder.InsertData(
                table: "ApplicationUsers",
                columns: new[] { "Id", "AccessFailedCount", "CreatedBy", "CreatedDate", "Email", "FirstName", "IsActive", "IsLocked", "LastModifiedBy", "LastModifiedDate", "LastName", "PasswordHash", "PhoneNumber", "Role" },
                values: new object[] { 2, 0, "Seed", new DateTimeOffset(new DateTime(2024, 2, 10, 16, 55, 40, 996, DateTimeKind.Unspecified).AddTicks(7599), new TimeSpan(0, 1, 0, 0, 0)), "dwigsch123@foodie.com", "Dwight", true, false, null, null, "Schrute", "$2a$11$gca0hBs5g6QBK0guE8N0Fu3hugProCw0k.GVc965j91s37pewkGg6", "123-456-789", 2 });

            migrationBuilder.InsertData(
                table: "Admins",
                column: "Id",
                value: 1);

            migrationBuilder.InsertData(
                table: "Customers",
                column: "Id",
                value: 3);

            migrationBuilder.InsertData(
                table: "OrderHandlers",
                columns: new[] { "Id", "LocationId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "RefreshTokens",
                columns: new[] { "Id", "ApplicationUserId", "CreatedBy", "CreatedDate", "ExpirationTime", "LastModifiedBy", "LastModifiedDate", "Token" },
                values: new object[,]
                {
                    { 1, 1, "Seed", new DateTimeOffset(new DateTime(2024, 2, 10, 16, 55, 41, 300, DateTimeKind.Unspecified).AddTicks(4460), new TimeSpan(0, 1, 0, 0, 0)), null, null, null, null },
                    { 3, 3, "Seed", new DateTimeOffset(new DateTime(2024, 2, 10, 16, 55, 41, 300, DateTimeKind.Unspecified).AddTicks(4603), new TimeSpan(0, 1, 0, 0, 0)), null, null, null, null },
                    { 2, 2, "Seed", new DateTimeOffset(new DateTime(2024, 2, 10, 16, 55, 41, 300, DateTimeKind.Unspecified).AddTicks(4593), new TimeSpan(0, 1, 0, 0, 0)), null, null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_ApplicationUserId",
                table: "RefreshTokens",
                column: "ApplicationUserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "OrderHandlers");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "ApplicationUsers");
        }
    }
}

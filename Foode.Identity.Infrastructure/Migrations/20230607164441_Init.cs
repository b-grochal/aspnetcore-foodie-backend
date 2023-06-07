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

            migrationBuilder.InsertData(
                table: "ApplicationUsers",
                columns: new[] { "Id", "AccessFailedCount", "CreatedBy", "CreatedDate", "Email", "FirstName", "IsLocked", "LastModifiedBy", "LastModifiedDate", "LastName", "PasswordHash", "PhoneNumber", "Role" },
                values: new object[] { 1, 0, "Seed", new DateTimeOffset(new DateTime(2023, 6, 7, 18, 44, 40, 374, DateTimeKind.Unspecified).AddTicks(7399), new TimeSpan(0, 2, 0, 0, 0)), "michsco123@foodie.com", "Michael", false, null, null, "Scott", "$2a$11$cEzx63FL1Pub5FcY5jFAEONMr9uX2krZly94m0boRqBP5cdIaI24y", "123-456-789", 1 });

            migrationBuilder.InsertData(
                table: "ApplicationUsers",
                columns: new[] { "Id", "AccessFailedCount", "CreatedBy", "CreatedDate", "Email", "FirstName", "IsLocked", "LastModifiedBy", "LastModifiedDate", "LastName", "PasswordHash", "PhoneNumber", "Role" },
                values: new object[] { 3, 0, "Seed", new DateTimeOffset(new DateTime(2023, 6, 7, 18, 44, 40, 713, DateTimeKind.Unspecified).AddTicks(4904), new TimeSpan(0, 2, 0, 0, 0)), "jimhal123@foodie.com", "Jim", false, null, null, "Halpert", "$2a$11$wM.7AfiX9cxLcwL0xfIAWe0ZQNmnnIP5av04qEm1r4Mzg0lrh7KHe", "123-456-789", 3 });

            migrationBuilder.InsertData(
                table: "ApplicationUsers",
                columns: new[] { "Id", "AccessFailedCount", "CreatedBy", "CreatedDate", "Email", "FirstName", "IsLocked", "LastModifiedBy", "LastModifiedDate", "LastName", "PasswordHash", "PhoneNumber", "Role" },
                values: new object[] { 2, 0, "Seed", new DateTimeOffset(new DateTime(2023, 6, 7, 18, 44, 40, 555, DateTimeKind.Unspecified).AddTicks(161), new TimeSpan(0, 2, 0, 0, 0)), "dwigsch123@foodie.com", "Dwight", false, null, null, "Schrute", "$2a$11$0F8kldF/MiAFyl2XAgd83OmFiTIpn3bAgcE9H5Ait4XtN7VY.zd72", "123-456-789", 2 });

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
                name: "ApplicationUsers");
        }
    }
}

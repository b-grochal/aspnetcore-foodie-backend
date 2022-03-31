using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Foodie.Meals.Infrastructure.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    RestaurantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.RestaurantId);
                });

            migrationBuilder.CreateTable(
                name: "CategoryRestaurant",
                columns: table => new
                {
                    CategoriesCategoryId = table.Column<int>(type: "int", nullable: false),
                    RestaurantsRestaurantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryRestaurant", x => new { x.CategoriesCategoryId, x.RestaurantsRestaurantId });
                    table.ForeignKey(
                        name: "FK_CategoryRestaurant_Categories_CategoriesCategoryId",
                        column: x => x.CategoriesCategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryRestaurant_Restaurants_RestaurantsRestaurantId",
                        column: x => x.RestaurantsRestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "RestaurantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    RestaurantId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_Locations_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Locations_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "RestaurantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    MealId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RestaurantId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.MealId);
                    table.ForeignKey(
                        name: "FK_Meals_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "RestaurantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, "Seed", new DateTimeOffset(new DateTime(2022, 3, 31, 13, 42, 44, 176, DateTimeKind.Unspecified).AddTicks(656), new TimeSpan(0, 2, 0, 0, 0)), null, null, "Pasta" },
                    { 2, "Seed", new DateTimeOffset(new DateTime(2022, 3, 31, 13, 42, 44, 182, DateTimeKind.Unspecified).AddTicks(3345), new TimeSpan(0, 2, 0, 0, 0)), null, null, "Burger" },
                    { 3, "Seed", new DateTimeOffset(new DateTime(2022, 3, 31, 13, 42, 44, 182, DateTimeKind.Unspecified).AddTicks(3428), new TimeSpan(0, 2, 0, 0, 0)), null, null, "Pizza" },
                    { 4, "Seed", new DateTimeOffset(new DateTime(2022, 3, 31, 13, 42, 44, 182, DateTimeKind.Unspecified).AddTicks(3442), new TimeSpan(0, 2, 0, 0, 0)), null, null, "Salad" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "Country", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, "USA", "Seed", new DateTimeOffset(new DateTime(2022, 3, 31, 13, 42, 44, 186, DateTimeKind.Unspecified).AddTicks(2882), new TimeSpan(0, 2, 0, 0, 0)), null, null, "Las Vegas" },
                    { 2, "USA", "Seed", new DateTimeOffset(new DateTime(2022, 3, 31, 13, 42, 44, 186, DateTimeKind.Unspecified).AddTicks(2975), new TimeSpan(0, 2, 0, 0, 0)), null, null, "Los Angeles" },
                    { 3, "USA", "Seed", new DateTimeOffset(new DateTime(2022, 3, 31, 13, 42, 44, 186, DateTimeKind.Unspecified).AddTicks(2990), new TimeSpan(0, 2, 0, 0, 0)), null, null, "New York" }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "RestaurantId", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, "Seed", new DateTimeOffset(new DateTime(2022, 3, 31, 13, 42, 44, 191, DateTimeKind.Unspecified).AddTicks(98), new TimeSpan(0, 2, 0, 0, 0)), null, null, "KFC" },
                    { 2, "Seed", new DateTimeOffset(new DateTime(2022, 3, 31, 13, 42, 44, 191, DateTimeKind.Unspecified).AddTicks(209), new TimeSpan(0, 2, 0, 0, 0)), null, null, "Pizza Hut" },
                    { 3, "Seed", new DateTimeOffset(new DateTime(2022, 3, 31, 13, 42, 44, 191, DateTimeKind.Unspecified).AddTicks(226), new TimeSpan(0, 2, 0, 0, 0)), null, null, "McDonald's" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "Address", "CityId", "CreatedBy", "CreatedDate", "Email", "LastModifiedBy", "LastModifiedDate", "PhoneNumber", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "Kfc Las Vegas", 1, "Seed", new DateTimeOffset(new DateTime(2022, 3, 31, 13, 42, 44, 187, DateTimeKind.Unspecified).AddTicks(8913), new TimeSpan(0, 2, 0, 0, 0)), "kfc.lasvegas@email.com", null, null, "123-123-213", 1 },
                    { 2, "Kfc Los Angeles", 2, "Seed", new DateTimeOffset(new DateTime(2022, 3, 31, 13, 42, 44, 187, DateTimeKind.Unspecified).AddTicks(9007), new TimeSpan(0, 2, 0, 0, 0)), "kfc.losangeles@email.com", null, null, "123-123-213", 1 },
                    { 3, "Kfc New York", 3, "Seed", new DateTimeOffset(new DateTime(2022, 3, 31, 13, 42, 44, 187, DateTimeKind.Unspecified).AddTicks(9022), new TimeSpan(0, 2, 0, 0, 0)), "kfc.newyork@email.com", null, null, "123-123-213", 1 },
                    { 4, "Pizza Hut Las Vegas", 1, "Seed", new DateTimeOffset(new DateTime(2022, 3, 31, 13, 42, 44, 187, DateTimeKind.Unspecified).AddTicks(9053), new TimeSpan(0, 2, 0, 0, 0)), "pizzahut.lasvegas@email.com", null, null, "123-123-213", 2 },
                    { 5, "Pizza Hut Los Angeles", 2, "Seed", new DateTimeOffset(new DateTime(2022, 3, 31, 13, 42, 44, 187, DateTimeKind.Unspecified).AddTicks(9064), new TimeSpan(0, 2, 0, 0, 0)), "pizzahut.losangeles@email.com", null, null, "123-123-213", 2 },
                    { 6, "McDonald's Las Vegas", 1, "Seed", new DateTimeOffset(new DateTime(2022, 3, 31, 13, 42, 44, 187, DateTimeKind.Unspecified).AddTicks(9088), new TimeSpan(0, 2, 0, 0, 0)), "mcdonalds.lasvegas@email.com", null, null, "123-123-213", 3 }
                });

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "MealId", "CreatedBy", "CreatedDate", "Description", "LastModifiedBy", "LastModifiedDate", "Name", "Price", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "Seed", new DateTimeOffset(new DateTime(2022, 3, 31, 13, 42, 44, 190, DateTimeKind.Unspecified).AddTicks(28), new TimeSpan(0, 2, 0, 0, 0)), "Longer", null, null, "Longer", 12m, 1 },
                    { 2, "Seed", new DateTimeOffset(new DateTime(2022, 3, 31, 13, 42, 44, 190, DateTimeKind.Unspecified).AddTicks(161), new TimeSpan(0, 2, 0, 0, 0)), "Zinger", null, null, "Zinger", 10m, 1 },
                    { 3, "Seed", new DateTimeOffset(new DateTime(2022, 3, 31, 13, 42, 44, 190, DateTimeKind.Unspecified).AddTicks(180), new TimeSpan(0, 2, 0, 0, 0)), "Pizza Texas", null, null, "Pizza Texas", 12m, 2 },
                    { 4, "Seed", new DateTimeOffset(new DateTime(2022, 3, 31, 13, 42, 44, 190, DateTimeKind.Unspecified).AddTicks(193), new TimeSpan(0, 2, 0, 0, 0)), "Pizza Carbonara", null, null, "Pizza Carbonara", 12m, 2 },
                    { 5, "Seed", new DateTimeOffset(new DateTime(2022, 3, 31, 13, 42, 44, 190, DateTimeKind.Unspecified).AddTicks(427), new TimeSpan(0, 2, 0, 0, 0)), "Big Mac", null, null, "Big Mac", 15m, 3 },
                    { 6, "Seed", new DateTimeOffset(new DateTime(2022, 3, 31, 13, 42, 44, 190, DateTimeKind.Unspecified).AddTicks(457), new TimeSpan(0, 2, 0, 0, 0)), "McRoyal", null, null, "McRoyal", 10m, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryRestaurant_RestaurantsRestaurantId",
                table: "CategoryRestaurant",
                column: "RestaurantsRestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CityId",
                table: "Locations",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_RestaurantId",
                table: "Locations",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_RestaurantId",
                table: "Meals",
                column: "RestaurantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryRestaurant");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Restaurants");
        }
    }
}

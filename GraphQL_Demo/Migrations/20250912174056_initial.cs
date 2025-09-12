using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GraphQL_Demo.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfGuests = table.Column<int>(type: "int", nullable: false),
                    SpecialRequests = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactInfo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menus_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Start your meal right!", "Appetizers" },
                    { 2, "Hearty and satisfying meals.", "Main Course" },
                    { 3, "Sweet treats to end your meal.", "Desserts" }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "ContactInfo", "CustomerName", "NumberOfGuests", "ReservationDate", "SpecialRequests" },
                values: new object[,]
                {
                    { 1, "john@example.com", "John Doe", 2, new DateTime(2025, 9, 15, 19, 0, 0, 0, DateTimeKind.Unspecified), "Window seat, please." },
                    { 2, "alice.smith@example.com", "Alice Smith", 4, new DateTime(2025, 9, 16, 20, 30, 0, 0, DateTimeKind.Unspecified), "Vegetarian options." },
                    { 3, "michael.j@example.com", "Michael Johnson", 6, new DateTime(2025, 9, 17, 18, 45, 0, 0, DateTimeKind.Unspecified), "Birthday celebration." },
                    { 4, "sara.lee@example.com", "Sara Lee", 3, new DateTime(2025, 9, 18, 21, 15, 0, 0, DateTimeKind.Unspecified), "No peanuts, please." }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Crispy garlic bread served with marinara sauce.", "/images/garlic_bread.jpg", "Garlic Bread", 5.9900000000000002 },
                    { 2, 1, "Toasted bread topped with fresh tomatoes, garlic, and basil.", "/images/bruschetta.jpg", "Bruschetta", 6.4900000000000002 },
                    { 3, 2, "Juicy grilled chicken with herb butter and vegetables.", "/images/grilled_chicken.jpg", "Grilled Chicken", 13.99 },
                    { 4, 2, "Classic Italian lasagna with layers of beef and cheese.", "/images/lasagna.jpg", "Beef Lasagna", 14.5 },
                    { 5, 3, "Moist chocolate cake with rich ganache frosting.", "/images/chocolate_cake.jpg", "Chocolate Cake", 7.25 },
                    { 6, 3, "Classic coffee-flavored Italian dessert with mascarpone.", "/images/tiramisu.jpg", "Tiramisu", 7.75 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menus_CategoryId",
                table: "Menus",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}

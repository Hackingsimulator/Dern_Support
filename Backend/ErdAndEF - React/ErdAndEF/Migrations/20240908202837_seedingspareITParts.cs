using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ErdAndEF.Migrations
{
    /// <inheritdoc />
    public partial class seedingspareITParts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 396061120);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 405288325);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1812855181);

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { -57745977, null, "CanDelete", "user" },
                    { 863300589, null, "CanDelete", "admin" },
                    { 2080718066, null, "CanCreate", "admin" }
                });

            migrationBuilder.InsertData(
                table: "ITStocksDb",
                columns: new[] { "Id", "Category", "Description", "Name", "QuantityInStock" },
                values: new object[,]
                {
                    { 1, "Laptop", "Dell Latitude 5500", "Laptop", 5 },
                    { 2, "Battery", "Dell XPS 13 Battery", "Battery", 10 },
                    { 3, "Screen", "15.6 inch FHD Screen", "Screen", 8 },
                    { 4, "RAM", "8GB DDR4 RAM", "RAM", 20 },
                    { 5, "Storage", "1TB SSD", "Hard Drive", 15 },
                    { 6, "Keyboard", "Mechanical Keyboard", "Keyboard", 12 },
                    { 7, "Charger", "65W USB-C Charger", "Charger", 18 },
                    { 8, "Laptop", "Dell Latitude Motherboard", "Motherboard", 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -57745977);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 863300589);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 2080718066);

            migrationBuilder.DeleteData(
                table: "ITStocksDb",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ITStocksDb",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ITStocksDb",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ITStocksDb",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ITStocksDb",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ITStocksDb",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ITStocksDb",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ITStocksDb",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 396061120, null, "CanDelete", "admin" },
                    { 405288325, null, "CanDelete", "user" },
                    { 1812855181, null, "CanCreate", "admin" }
                });
        }
    }
}

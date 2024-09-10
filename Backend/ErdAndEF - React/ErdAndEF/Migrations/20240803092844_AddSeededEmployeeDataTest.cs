using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ErdAndEF.Migrations
{
    /// <inheritdoc />
    public partial class AddSeededEmployeeDataTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 6, "Anymail@gmail.com", "Ahmad", "Mohsen", "022555554" },
                    { 7, "Anymail@gmail.com", "Essa", "Mohsen", "022555554" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}

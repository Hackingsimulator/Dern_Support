using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ErdAndEF.Migrations
{
    /// <inheritdoc />
    public partial class addedSeedDataforEmployeeProjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EmployeeProjectsDBset",
                columns: new[] { "EmployeeID", "ProjectID" },
                values: new object[,]
                {
                    { 6, 1 },
                    { 7, 1 },
                    { 6, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmployeeProjectsDBset",
                keyColumns: new[] { "EmployeeID", "ProjectID" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "EmployeeProjectsDBset",
                keyColumns: new[] { "EmployeeID", "ProjectID" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "EmployeeProjectsDBset",
                keyColumns: new[] { "EmployeeID", "ProjectID" },
                keyValues: new object[] { 6, 2 });
        }
    }
}

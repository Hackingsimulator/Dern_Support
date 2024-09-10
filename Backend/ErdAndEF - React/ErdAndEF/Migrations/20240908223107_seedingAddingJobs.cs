using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ErdAndEF.Migrations
{
    /// <inheritdoc />
    public partial class seedingAddingJobs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "JobsDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScheduledDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobsDb", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { -2031013919, null, "CanDelete", "admin" },
                    { -313678871, null, "CanDelete", "user" },
                    { 413580643, null, "CanCreate", "admin" }
                });

            migrationBuilder.InsertData(
                table: "JobsDb",
                columns: new[] { "Id", "Description", "Priority", "ScheduledDate", "Status", "Title" },
                values: new object[,]
                {
                    { 1, "Fix WiFi connectivity issue in the office.", "High", "", "Pending", "Network Issue Resolution" },
                    { 2, "Install Visual Studio on employee laptops.", "High", "", "Pending", "Install Software" },
                    { 3, "Replace faulty RAM in server rack 1.", "Medium", "", "New", "Hardware Upgrade" },
                    { 4, "Perform routine maintenance on printers in all offices.", "Low", "", "Pending", "Printer Maintenance" },
                    { 5, "Create new user accounts for incoming employees.", "Medium", "", "Pending", "User Account Setup" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobsDb");

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -2031013919);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -313678871);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 413580643);

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { -57745977, null, "CanDelete", "user" },
                    { 863300589, null, "CanDelete", "admin" },
                    { 2080718066, null, "CanCreate", "admin" }
                });
        }
    }
}

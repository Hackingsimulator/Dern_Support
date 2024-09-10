using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ErdAndEF.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "Status",
                table: "JobsDb");

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { -1221484457, null, "CanDelete", "admin" },
                    { 500419907, null, "CanCreate", "admin" },
                    { 1539720495, null, "CanDelete", "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -1221484457);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 500419907);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1539720495);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "JobsDb",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { -2031013919, null, "CanDelete", "admin" },
                    { -313678871, null, "CanDelete", "user" },
                    { 413580643, null, "CanCreate", "admin" }
                });

            migrationBuilder.UpdateData(
                table: "JobsDb",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: "Pending");

            migrationBuilder.UpdateData(
                table: "JobsDb",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: "Pending");

            migrationBuilder.UpdateData(
                table: "JobsDb",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: "New");

            migrationBuilder.UpdateData(
                table: "JobsDb",
                keyColumn: "Id",
                keyValue: 4,
                column: "Status",
                value: "Pending");

            migrationBuilder.UpdateData(
                table: "JobsDb",
                keyColumn: "Id",
                keyValue: 5,
                column: "Status",
                value: "Pending");
        }
    }
}

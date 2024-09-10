using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ErdAndEF.Migrations
{
    /// <inheritdoc />
    public partial class employeeTaskTable3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTasksDb_employees_EmployeeId",
                table: "EmployeeTasksDb");

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -537295353);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 556904940);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1560855434);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "EmployeeTasksDb",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { -800822727, null, "CanDelete", "user" },
                    { -410847338, null, "CanCreate", "admin" },
                    { 606853944, null, "CanDelete", "admin" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTasksDb_employees_EmployeeId",
                table: "EmployeeTasksDb",
                column: "EmployeeId",
                principalTable: "employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTasksDb_employees_EmployeeId",
                table: "EmployeeTasksDb");

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -800822727);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -410847338);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 606853944);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "EmployeeTasksDb",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { -537295353, null, "CanCreate", "admin" },
                    { 556904940, null, "CanDelete", "user" },
                    { 1560855434, null, "CanDelete", "admin" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTasksDb_employees_EmployeeId",
                table: "EmployeeTasksDb",
                column: "EmployeeId",
                principalTable: "employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

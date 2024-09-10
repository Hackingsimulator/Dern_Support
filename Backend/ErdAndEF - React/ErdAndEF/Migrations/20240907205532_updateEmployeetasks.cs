using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ErdAndEF.Migrations
{
    /// <inheritdoc />
    public partial class updateEmployeetasks : Migration
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
                keyValue: -1375750729);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: -1234392979);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1723133778);

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
                    { -520521690, null, "CanDelete", "admin" },
                    { 451561866, null, "CanCreate", "admin" },
                    { 910702900, null, "CanDelete", "user" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTasksDb_employees_EmployeeId",
                table: "EmployeeTasksDb",
                column: "EmployeeId",
                principalTable: "employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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
                keyValue: -520521690);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 451561866);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 910702900);

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
                    { -1375750729, null, "CanCreate", "admin" },
                    { -1234392979, null, "CanDelete", "admin" },
                    { 1723133778, null, "CanDelete", "user" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTasksDb_employees_EmployeeId",
                table: "EmployeeTasksDb",
                column: "EmployeeId",
                principalTable: "employees",
                principalColumn: "Id");
        }
    }
}

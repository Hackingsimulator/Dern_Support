using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ErdAndEF.Migrations
{
    /// <inheritdoc />
    public partial class addedEmployeeDbset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeProjects_Projects_ProjectID",
                table: "EmployeeProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeProjects_employees_EmployeeID",
                table: "EmployeeProjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeProjects",
                table: "EmployeeProjects");

            migrationBuilder.RenameTable(
                name: "EmployeeProjects",
                newName: "EmployeeProjectsDBset");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeProjects_EmployeeID",
                table: "EmployeeProjectsDBset",
                newName: "IX_EmployeeProjectsDBset_EmployeeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeProjectsDBset",
                table: "EmployeeProjectsDBset",
                columns: new[] { "ProjectID", "EmployeeID" });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeProjectsDBset_Projects_ProjectID",
                table: "EmployeeProjectsDBset",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeProjectsDBset_employees_EmployeeID",
                table: "EmployeeProjectsDBset",
                column: "EmployeeID",
                principalTable: "employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeProjectsDBset_Projects_ProjectID",
                table: "EmployeeProjectsDBset");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeProjectsDBset_employees_EmployeeID",
                table: "EmployeeProjectsDBset");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeProjectsDBset",
                table: "EmployeeProjectsDBset");

            migrationBuilder.RenameTable(
                name: "EmployeeProjectsDBset",
                newName: "EmployeeProjects");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeProjectsDBset_EmployeeID",
                table: "EmployeeProjects",
                newName: "IX_EmployeeProjects_EmployeeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeProjects",
                table: "EmployeeProjects",
                columns: new[] { "ProjectID", "EmployeeID" });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeProjects_Projects_ProjectID",
                table: "EmployeeProjects",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeProjects_employees_EmployeeID",
                table: "EmployeeProjects",
                column: "EmployeeID",
                principalTable: "employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

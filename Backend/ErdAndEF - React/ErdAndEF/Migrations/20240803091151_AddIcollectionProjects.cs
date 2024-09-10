using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ErdAndEF.Migrations
{
    /// <inheritdoc />
    public partial class AddIcollectionProjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeProjects",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    ProjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeProjects", x => new { x.ProjectID, x.EmployeeID });
                    table.ForeignKey(
                        name: "FK_EmployeeProjects_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeProjects_employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProjects_EmployeeID",
                table: "EmployeeProjects",
                column: "EmployeeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeProjects");
        }
    }
}

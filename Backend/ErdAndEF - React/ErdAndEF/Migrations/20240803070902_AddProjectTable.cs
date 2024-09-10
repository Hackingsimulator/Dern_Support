using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ErdAndEF.Migrations
{
    /// <inheritdoc />
    public partial class AddProjectTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "employees");

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Budget = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hours = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

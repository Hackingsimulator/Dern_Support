using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ErdAndEF.Migrations
{
    /// <inheritdoc />
    public partial class phoneNumertoEmployees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "employees");
        }
    }
}

﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ErdAndEF.Migrations
{
    /// <inheritdoc />
    public partial class postalcodeEmployees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "employees");
        }
    }
}

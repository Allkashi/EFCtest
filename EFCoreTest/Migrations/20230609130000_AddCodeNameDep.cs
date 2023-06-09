using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreTest.Migrations
{
    /// <inheritdoc />
    public partial class AddCodeNameDep : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CODE_DEP_NAME",
                table: "department",
                comment: "Кодовое наименование отдела",
                maxLength: 10,
                nullable: true,
                defaultValue: 0);
        
    }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "job");

            migrationBuilder.DropTable(
                name: "department");
        }
    }
}

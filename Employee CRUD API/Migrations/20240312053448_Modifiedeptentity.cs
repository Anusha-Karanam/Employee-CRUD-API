using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee_CRUD_API.Migrations
{
    /// <inheritdoc />
    public partial class Modifiedeptentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Department",
                newName: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Department",
                newName: "Id");
        }
    }
}

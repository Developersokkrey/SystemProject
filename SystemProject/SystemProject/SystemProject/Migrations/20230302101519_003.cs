using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemProject.Migrations
{
    public partial class _003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DepartmentID",
                table: "USERPRIVI",
                newName: "DepmentID");

            migrationBuilder.RenameColumn(
                name: "DepartmentID",
                table: "OUSR",
                newName: "DepmentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DepmentID",
                table: "USERPRIVI",
                newName: "DepartmentID");

            migrationBuilder.RenameColumn(
                name: "DepmentID",
                table: "OUSR",
                newName: "DepartmentID");
        }
    }
}

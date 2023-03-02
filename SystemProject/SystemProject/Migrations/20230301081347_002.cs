using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemProject.Migrations
{
    public partial class _002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentID",
                table: "USERPRIVI",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentID",
                table: "OUSR",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EmpCode",
                table: "OUSR",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpName",
                table: "OUSR",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "OCURE",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "COMP",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "BRINFO",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "BRAN",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DEPMENT",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Enable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEPMENT", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DEPMENT");

            migrationBuilder.DropColumn(
                name: "DepartmentID",
                table: "USERPRIVI");

            migrationBuilder.DropColumn(
                name: "DepartmentID",
                table: "OUSR");

            migrationBuilder.DropColumn(
                name: "EmpCode",
                table: "OUSR");

            migrationBuilder.DropColumn(
                name: "EmpName",
                table: "OUSR");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "OCURE");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "COMP");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "BRINFO");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "BRAN");
        }
    }
}

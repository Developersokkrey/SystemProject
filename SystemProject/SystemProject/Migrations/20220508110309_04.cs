using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemProject.Migrations
{
    public partial class _04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BranID",
                table: "OUSR",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BranID",
                table: "OUSR");
        }
    }
}

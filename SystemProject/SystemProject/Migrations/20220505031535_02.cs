using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemProject.Migrations
{
    public partial class _02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BRAN",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BRAN", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BRINFO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranID = table.Column<int>(type: "int", nullable: false),
                    Tel1 = table.Column<int>(type: "int", nullable: false),
                    Tel2 = table.Column<int>(type: "int", nullable: false),
                    Tel3 = table.Column<int>(type: "int", nullable: false),
                    Tel4 = table.Column<int>(type: "int", nullable: false),
                    Tel5 = table.Column<int>(type: "int", nullable: false),
                    Des1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Des2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BRINFO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "COMP",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SC = table.Column<int>(type: "int", nullable: false),
                    LC = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMP", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BRAN");

            migrationBuilder.DropTable(
                name: "BRINFO");

            migrationBuilder.DropTable(
                name: "COMP");
        }
    }
}

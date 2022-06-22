using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemProject.Migrations
{
    public partial class _01 : Migration
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
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SC = table.Column<int>(type: "int", nullable: false),
                    LC = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMP", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EXRATE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrID = table.Column<int>(type: "int", nullable: false),
                    Rate1 = table.Column<decimal>(type: "decimal(36,18)", nullable: false),
                    Rate2 = table.Column<decimal>(type: "decimal(36,18)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXRATE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OCURE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Des = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OCURE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OUSR",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rule = table.Column<int>(type: "int", nullable: false),
                    ComID = table.Column<int>(type: "int", nullable: false),
                    BranID = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OUSR", x => x.ID);
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

            migrationBuilder.DropTable(
                name: "EXRATE");

            migrationBuilder.DropTable(
                name: "OCURE");

            migrationBuilder.DropTable(
                name: "OUSR");
        }
    }
}

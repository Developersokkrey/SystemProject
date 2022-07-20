using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SystemProject.Migrations
{
    public partial class _001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BRAN",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    ComID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BRAN", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BRINFO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Logo = table.Column<string>(type: "text", nullable: true),
                    BranID = table.Column<int>(type: "integer", nullable: false),
                    Tel1 = table.Column<int>(type: "integer", nullable: false),
                    Tel2 = table.Column<int>(type: "integer", nullable: false),
                    Tel3 = table.Column<int>(type: "integer", nullable: false),
                    Tel4 = table.Column<int>(type: "integer", nullable: false),
                    Tel5 = table.Column<int>(type: "integer", nullable: false),
                    Des1 = table.Column<string>(type: "text", nullable: true),
                    Des2 = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BRINFO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "COMP",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Logo = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    SC = table.Column<int>(type: "integer", nullable: false),
                    LC = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMP", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EXRATE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CurrID = table.Column<int>(type: "integer", nullable: false),
                    Rate1 = table.Column<decimal>(type: "numeric(36,18)", nullable: false),
                    Rate2 = table.Column<decimal>(type: "numeric(36,18)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXRATE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OCURE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Des = table.Column<string>(type: "text", nullable: true),
                    Symbol = table.Column<string>(type: "text", nullable: true),
                    ComID = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OCURE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OUSR",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: true),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    Rule = table.Column<int>(type: "integer", nullable: false),
                    ComID = table.Column<int>(type: "integer", nullable: false),
                    BranID = table.Column<int>(type: "integer", nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
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

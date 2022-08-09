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
                    ID = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    ComID = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BRAN", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BRINFO",
                columns: table => new
                {
                    ID = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Logo = table.Column<string>(type: "text", nullable: true),
                    BranID = table.Column<string>(type: "text", nullable: true),
                    Tel1 = table.Column<string>(type: "text", nullable: true),
                    Tel2 = table.Column<string>(type: "text", nullable: true),
                    Tel3 = table.Column<string>(type: "text", nullable: true),
                    Tel4 = table.Column<string>(type: "text", nullable: true),
                    Tel5 = table.Column<string>(type: "text", nullable: true),
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
                    ID = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Logo = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    SC = table.Column<string>(type: "text", nullable: true),
                    LC = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMP", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EXRATE",
                columns: table => new
                {
                    ID = table.Column<string>(type: "text", nullable: false),
                    CurrID = table.Column<string>(type: "text", nullable: true),
                    Rate1 = table.Column<decimal>(type: "numeric(36,18)", nullable: false),
                    Rate2 = table.Column<decimal>(type: "numeric(36,18)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXRATE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FUNCTI",
                columns: table => new
                {
                    ID = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FUNCTI", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OCURE",
                columns: table => new
                {
                    ID = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Des = table.Column<string>(type: "text", nullable: true),
                    Symbol = table.Column<string>(type: "text", nullable: true),
                    ComID = table.Column<string>(type: "text", nullable: true),
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
                    ID = table.Column<string>(type: "text", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: true),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    RoleID = table.Column<string>(type: "text", nullable: true),
                    ComID = table.Column<string>(type: "text", nullable: true),
                    BranID = table.Column<string>(type: "text", nullable: true),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OUSR", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PRIMARYKEYS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TableName = table.Column<int>(type: "integer", nullable: false),
                    KeyNumber = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRIMARYKEYS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ROLEPRIVI",
                columns: table => new
                {
                    ID = table.Column<string>(type: "text", nullable: false),
                    RoleID = table.Column<string>(type: "text", nullable: true),
                    FuncID = table.Column<string>(type: "text", nullable: true),
                    Enable = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLEPRIVI", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ROLES",
                columns: table => new
                {
                    ID = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Enable = table.Column<bool>(type: "boolean", nullable: false),
                    ComID = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USERPRIVI",
                columns: table => new
                {
                    ID = table.Column<string>(type: "text", nullable: false),
                    UserID = table.Column<string>(type: "text", nullable: true),
                    RolePriviID = table.Column<string>(type: "text", nullable: true),
                    FuncID = table.Column<string>(type: "text", nullable: true),
                    Enable = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERPRIVI", x => x.ID);
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
                name: "FUNCTI");

            migrationBuilder.DropTable(
                name: "OCURE");

            migrationBuilder.DropTable(
                name: "OUSR");

            migrationBuilder.DropTable(
                name: "PRIMARYKEYS");

            migrationBuilder.DropTable(
                name: "ROLEPRIVI");

            migrationBuilder.DropTable(
                name: "ROLES");

            migrationBuilder.DropTable(
                name: "USERPRIVI");
        }
    }
}

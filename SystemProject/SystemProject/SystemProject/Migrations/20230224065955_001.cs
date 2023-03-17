using Microsoft.EntityFrameworkCore.Migrations;

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
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BRAN", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BRINFO",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tel1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tel2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tel3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tel4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tel5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LC = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMP", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CUSMER",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ComID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSMER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EXRATE",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CurrID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate1 = table.Column<decimal>(type: "decimal(36,18)", nullable: false),
                    Rate2 = table.Column<decimal>(type: "decimal(36,18)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXRATE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FUNCTI",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FUNCTI", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OCURE",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Des = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComID = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OUSR", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PRIMARYKEYS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableName = table.Column<int>(type: "int", nullable: false),
                    KeyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRIMARYKEYS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ROLEPRIVI",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FuncID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Enable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLEPRIVI", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ROLES",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Enable = table.Column<bool>(type: "bit", nullable: false),
                    ComID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USERPRIVI",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RolePriviID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FuncID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Enable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERPRIVI", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VENDOR",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ComID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VENDOR", x => x.ID);
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
                name: "CUSMER");

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

            migrationBuilder.DropTable(
                name: "VENDOR");
        }
    }
}

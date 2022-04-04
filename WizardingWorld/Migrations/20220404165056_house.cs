using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WizardingWorld.Migrations
{
    public partial class house : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "WizardingWorld",
                table: "Currencies",
                newName: "NativeName");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "WizardingWorld",
                table: "Countries",
                newName: "NativeName");

            migrationBuilder.AddColumn<string>(
                name: "EnglishName",
                schema: "WizardingWorld",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnglishName",
                schema: "WizardingWorld",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Houses",
                schema: "WizardingWorld",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HouseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FounderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeadOfHouseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Houses",
                schema: "WizardingWorld");

            migrationBuilder.DropColumn(
                name: "EnglishName",
                schema: "WizardingWorld",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "EnglishName",
                schema: "WizardingWorld",
                table: "Countries");

            migrationBuilder.RenameColumn(
                name: "NativeName",
                schema: "WizardingWorld",
                table: "Currencies",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "NativeName",
                schema: "WizardingWorld",
                table: "Countries",
                newName: "Name");
        }
    }
}

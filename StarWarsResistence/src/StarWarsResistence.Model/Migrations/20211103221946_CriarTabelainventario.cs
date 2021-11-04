using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace StarWarsResistence.Model.Migrations
{
    public partial class CriarTabelainventario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Rebeldes",
                schema: "dbo",
                table: "Rebeldes");

            migrationBuilder.RenameTable(
                name: "Rebeldes",
                schema: "dbo",
                newName: "Rebelde",
                newSchema: "dbo");

            migrationBuilder.AddColumn<string>(
                name: "nomeBase",
                schema: "dbo",
                table: "Rebelde",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rebelde",
                schema: "dbo",
                table: "Rebelde",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Inventario",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    idRebelde = table.Column<int>(type: "int", nullable: false),
                    Item = table.Column<string>(type: "text", nullable: true),
                    Pontos = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Localizacao",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdRebelde = table.Column<int>(type: "int", nullable: false),
                    local = table.Column<string>(type: "text", nullable: false),
                    Latitude = table.Column<double>(type: "double", nullable: false),
                    Longitude = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localizacao", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventario",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Localizacao",
                schema: "dbo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rebelde",
                schema: "dbo",
                table: "Rebelde");

            migrationBuilder.DropColumn(
                name: "nomeBase",
                schema: "dbo",
                table: "Rebelde");

            migrationBuilder.RenameTable(
                name: "Rebelde",
                schema: "dbo",
                newName: "Rebeldes",
                newSchema: "dbo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rebeldes",
                schema: "dbo",
                table: "Rebeldes",
                column: "Id");
        }
    }
}

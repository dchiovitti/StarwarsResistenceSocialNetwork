using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace StarWarsResistence.Model.Migrations
{
    public partial class CriandoTabelaDeRebeldes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "MyEntity",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Col = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rebeldes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "text", nullable: true),
                    idade = table.Column<int>(type: "int unsigned", nullable: false),
                    genero = table.Column<int>(type: "int", nullable: false),
                    statusRebelde = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rebeldes", x => x.Id);
                });
        }

        //protected override void Down(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.DropTable(
        //        name: "MyEntity",
        //        schema: "dbo");

        //    migrationBuilder.DropTable(
        //        name: "Rebeldes",
        //        schema: "dbo");
        //}
    }
}
